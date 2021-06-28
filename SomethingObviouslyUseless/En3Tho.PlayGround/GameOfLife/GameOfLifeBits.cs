using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace En3Tho.PlayGround.GameOfLife
{
    public delegate void GolBitsAction(GameOfLifeBitsView view);
    
    public unsafe class GameOfLifeBits
    {
        // Inner map contains actual values of calculation which then can be read of transferred somewhere
        // Outer map adds an another layer of values to contain mirrored value
        // Basically it looks like this:
        // [ o o o o o o o ]
        // [ o i i i i i o ]
        // [ o i i i i i o ]
        // [ o o o o o o o ]

        private readonly int _outerMapByteHeight;
        private readonly int _outerMapByteWidth;
        private readonly int _outerMapByteLength;

        private readonly int _innerMapByteWidth;
        private readonly int _innerMapByteHeight;

        private readonly byte* _outerMapStart;
        private readonly byte* _innerMapStart;
        private readonly byte* _buffer; // buffer has size of 2 rows of inner map

        private readonly byte* _lookupTable;

        public GameOfLifeBits(int width, int height, GolBitsAction init)
        {
            if (width % 8 > 0)
                throw new ArgumentException($"{nameof(width)} must be a multiple of 8");

            if (width / 8 % 2 > 0)
                throw new ArgumentException($"{nameof(width)} divided by 8 must be a multiple of 2");

            if (height < 2)
                throw new ArgumentException($"{nameof(height)} must not be less than 2");

            _innerMapByteWidth = width / 8;
            _innerMapByteHeight = height;

            _outerMapByteWidth = _innerMapByteWidth + 2;
            _outerMapByteHeight = _innerMapByteHeight + 2;
            _outerMapByteLength = _outerMapByteWidth * _outerMapByteHeight;

            var outerMap = GC.AllocateArray<byte>(_outerMapByteLength, pinned: true);

            _outerMapStart = (byte*)Unsafe.AsPointer(ref outerMap);//(byte*)GCHandle.Alloc(globalBuffer, GCHandleType.Pinned).AddrOfPinnedObject();
            _innerMapStart = _outerMapStart + _outerMapByteWidth + 1; // [1][1] index

            var buffer = GC.AllocateArray<byte>(_innerMapByteWidth * 2, pinned: true);
            _buffer = (byte*)Unsafe.AsPointer(ref buffer);

            var lookupTable = GetLookupTable();
            _lookupTable = (byte*)Unsafe.AsPointer(ref lookupTable);
            
            init(BitBuffer);
            CopySideBytes();
        }

        private void CopySideBytes()
        {
            // top row
            var innerBottomRight = _outerMapStart + _outerMapByteLength - _outerMapByteWidth - 2;
            *_outerMapStart = *innerBottomRight;
            var innerBottomLeft = innerBottomRight - _innerMapByteWidth + 1;
            Buffer.MemoryCopy(innerBottomLeft, _outerMapStart + 1, _innerMapByteWidth, _innerMapByteWidth);
            *(_outerMapStart + _outerMapByteWidth - 1) = *innerBottomLeft;

            // sides
            for (int i = 1; i < _outerMapByteHeight - 1; i++)
            {
                var outerMapFirst = _outerMapStart + i * _outerMapByteWidth;
                var outerMapLast = outerMapFirst + _outerMapByteWidth - 1;
                *outerMapFirst = *(outerMapLast - 1);
                *outerMapLast = *(outerMapFirst + 1);
            }

            //bottom row
            var outerBottomLeft = _outerMapStart + _outerMapByteLength - _outerMapByteWidth;
            *outerBottomLeft = *(_innerMapStart + _innerMapByteWidth - 1);
            Buffer.MemoryCopy(_innerMapStart, outerBottomLeft + 1, _innerMapByteWidth, _innerMapByteWidth);
            *(outerBottomLeft + _outerMapByteWidth - 1) = *_innerMapStart;
        }

        public GameOfLifeBitsView BitBuffer
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new GameOfLifeBitsView(new Span<byte>(_outerMapStart, _outerMapByteLength), _outerMapByteWidth);
        }

        public bool MoveNext()
        {
            MoveNextInternal2();
            CopySideBytes();
            return true;
        }

        private void MoveNextInternal2()
        {
            var world = _innerMapStart;
            var pWorld = _innerMapStart;
            var bufferRow1 = _buffer;
            var bufferRow2 = _buffer + _innerMapByteWidth;

            ProcessMiddleBlock(world, bufferRow1, 2, _innerMapByteWidth);
            world += _outerMapByteWidth << 1;

            while (world < _outerMapStart + _outerMapByteLength - _outerMapByteWidth - 1)
            {
                Buffer.MemoryCopy(bufferRow1, pWorld, _innerMapByteWidth, _innerMapByteWidth);
                ProcessMiddleBlock(world, bufferRow1, 1, _innerMapByteWidth);
                Buffer.MemoryCopy(bufferRow2, pWorld + _outerMapByteWidth, _innerMapByteWidth, _innerMapByteWidth);
                ProcessMiddleBlock(world + _innerMapByteWidth, bufferRow2, 1, _innerMapByteWidth);
                world += _outerMapByteWidth << 1;
                pWorld += _outerMapByteWidth << 1;
            }

            var lastRowStart = _outerMapStart + _outerMapByteLength - _outerMapByteWidth - _innerMapByteWidth - 1;

            if (_innerMapByteHeight % 2 == 0)
            {
                Buffer.MemoryCopy(bufferRow1, lastRowStart - _outerMapByteWidth, _innerMapByteWidth, _innerMapByteWidth);
                Buffer.MemoryCopy(bufferRow2, lastRowStart, _innerMapByteWidth, _innerMapByteWidth);
            }
            else
            {
                Buffer.MemoryCopy(bufferRow1, lastRowStart, _innerMapByteWidth, _innerMapByteWidth);
            }
        }

        // Here we assume we have unbounded access to any of near standing bytes
        // this way we can avoid using mod at every index calculation and read more bytes at once using uints
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private void ProcessMiddleBlock(byte* source, byte* dest, int rows, int rowWidth)
        {
            // construct a bit matrix of 3 bytes in the middle row and supplementary values at sides
            // 0  [1  2  3  4  5  6  7  8 ] 9
            // 10 [11 12 13 14 15 16 17 18] 19
            // 20 [21 22 23 24 25 26 27 28] 29

            // 0  prevTop    topByte        nextTop    9
            // 10 prevMiddle index (middle) nextMiddle 19
            // 20 prevBot    botByte        nextBot    29
            // 30 31 - ignore these

            // read 3 ints and convert 3 rows into bit matrix
            // 7  8  9  10 11 12 13 14 15 16 -> 0, 10, 20
            // 15 16 17 18 19 20 21 22 23 24 -> 0, 10, 20

            for (int currentRow = 0, startIndex = 0; currentRow < rows; currentRow++, startIndex += _outerMapByteWidth)
            {
                for (int cellIndex = startIndex; cellIndex < startIndex + rowWidth; cellIndex += 2)
                {
                    const uint FirstByteLookupMask = 0x1FF80;    // [0001][1111][1111][1000][0000]
                    const uint SecondByteLookupMask = 0x1FF8000; // [0001][1111][1111][1000][0000][0000][0000]

                    var firstRow = *(uint*)(source + cellIndex - _outerMapByteWidth - 1);
                    var secondRow = *(uint*)(source + cellIndex - 1);
                    var thirdRow = *(uint*)(source + cellIndex + _outerMapByteWidth - 1);

                    var lookupLeft = (firstRow & FirstByteLookupMask) >> 7   // 7 -> 0
                                   | (secondRow & FirstByteLookupMask) << 3  // 7 -> 10
                                   | (thirdRow & FirstByteLookupMask) << 13; // 7 -> 20
                    *dest++ = GetLookup(lookupLeft);

                    var lookupRight = (firstRow & SecondByteLookupMask) >> 15  // 15 -> 0
                                    | (secondRow & SecondByteLookupMask) >> 5  // 15 -> 10
                                    | (thirdRow & SecondByteLookupMask) << 5; // 15 -> 20
                    *dest++ = GetLookup(lookupRight);
                }
            }
        }

        // same logic with ProcessMiddle but slower as we need to count in infinite space thus byte indexing
        // used only for processing of frame bytes as every frame byte needs non optimal memory access
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessFrameByte(byte* source, byte* dest, int index, int rowWidth)
        {
            const byte LeftMask = 0x80; // [1xxx][xxxx]
            const byte RightMask = 0x1; // [xxxx][xxx1]

            var value = (uint)(*(source + (index - rowWidth - 1) % rowWidth) & LeftMask
                             | *(source + (index - rowWidth) % rowWidth) << 1
                             | (*(source + (index - rowWidth + 1) % rowWidth) & RightMask) << 9
                             | (*(source + (index - 1) % rowWidth) & LeftMask) << 10
                             | *source << 11
                             | (*(source + (index + 1) % rowWidth) & RightMask) << 19
                             | (*(source + (index + rowWidth - 1) % rowWidth) & LeftMask) << 20
                             | (*(source + (index + rowWidth) % rowWidth)) << 21
                             | (*(source + (index + rowWidth - 1) % rowWidth) & RightMask) << 29);

            *dest = GetLookup(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte GetLookup(uint value)
        {
            // read bit matrix as 2 separate parts and find byte value using 2 lookups
            // [] - left part, () - right part
            // [0  1  2  3  (4  5 ] 6  7  8  9 )
            // [10 11 12 13 (14 15] 16 17 18 19)
            // [20 21 22 23 (24 25] 26 27 28 29)
            // then convert to sequential representation

            const uint FirstPartLeft = 0x3F;                     // [0011][1111]
            const uint SecondPartLeft = 0xFC00;                  // [1111][1100][0000][0000]
            const uint ThirdPartLeft = 0x3F00000;                // [0011][1111][0000][0000][0000][0000][0000]
            uint leftLookupIndex = value & FirstPartLeft         // 0 -> 0 
                                 | (value & SecondPartLeft) >> 4 // 10 -> 6
                                 | (value & ThirdPartLeft) >> 8; // 20 -> 12

            const uint FirstPartRight = 0x3F0;                      // [0011][1111][0000]
            const uint SecondPartRight = 0xFC000;                   // [1111][1100][0000][0000][0000]
            const uint ThirdPartRight = 0x3F000000;                 // [0011][1111][0000][0000][0000][0000][0000][0000]
            uint rightLookupIndex = (value & FirstPartRight) >> 4   // 4 -> 0
                                  | (value & SecondPartRight) >> 8  // 14 -> 6
                                  | (value & ThirdPartRight) >> 12; // 24 -> 12

            var leftLookupPath = *(_lookupTable + leftLookupIndex);
            var rightLookupPart = *(_lookupTable + rightLookupIndex);

            return (byte)(leftLookupPath | rightLookupPart << 4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint MarkAlive(uint value, uint adjacentSum)
        {
            if (adjacentSum > 3) return 0;
            var result = (value | adjacentSum & 3) / 3;
            return result;
        }

        private static byte[] GetLookupTable() // Todo: settings?
        {
            var lookup = GC.AllocateArray<byte>(2 << 17, pinned: true); // 2^18
            for (uint lookupIndex = 0; lookupIndex < lookup.Length; lookupIndex++)
            {
                // convert from 0  1  2  3  4  5  to 0  1  2  3  4  5  and then process by 0  1  2  squares shifting 4 times
                //              6  7  8  9  10 11    10 11 12 13 14 15                     10 11 12
                //              12 13 14 15 16 17    20 21 22 23 24 25                     20 21 22

                const uint FirstRow = 0x3F;       // [0011][1111]
                const uint SecondRow = 0xFC0;     // [1111][1100][0000]
                const uint ThirdRow = 0x3F000;    // [0011][1111][0000][0000][0000]
                uint value = lookupIndex & FirstRow         // 0 -> 0
                           | (lookupIndex & SecondRow) << 4 // 6 -> 10
                           | (lookupIndex & ThirdRow) << 8; // 12 -> 20

                // then generate 6x3 lookup table
                // 0  1  2  3  4  5 
                // 10 11 12 13 14 15
                // 20 21 22 23 24 25
                // single lookup returns middle bits (11 12 13 14) as 0 1 2 3 

                const uint Square3x3 = 0x701407; // [0111][0000][0001][0100][0000][0111] - every bit except 11
                const int MiddleBitIndex = 11;    // [1000][0000][0000] - bit 11

                uint lookupValue = 0;
                for (int bitShift = 0; bitShift < 4; bitShift++) // 4 bits in a nibble
                {
                    var middleBit = value >> (MiddleBitIndex + bitShift) & 1;
                    var square = Square3x3 << bitShift & value;
                    lookupValue |= MarkAlive(middleBit, (uint)BitOperations.PopCount(square)) << bitShift;
                }

                lookup[lookupIndex] = (byte)lookupValue;
            }

            return lookup;
        }
    }
}