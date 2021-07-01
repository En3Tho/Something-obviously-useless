using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace En3Tho.PlayGround.Sudoku
{

    // TODO: Sudoku

    public ref struct BitWriter
    {
        public unsafe void Write<T>(ref T data, uint value, int offset, int length) where T : unmanaged
        {
            var dataSpan = MemoryMarshal.Cast<T, byte>(MemoryMarshal.CreateSpan(ref data, 1));
            var valueSpan = MemoryMarshal.Cast<uint, byte>(MemoryMarshal.CreateSpan(ref value, 1));
            var byteIndex = Math.DivRem(offset, 8, out var bitIndex);
            var byteCount = Math.DivRem(length, 8, out var bitLength);

            valueSpan.Slice(0, byteCount).CopyTo(dataSpan.Slice(byteIndex));
            dataSpan[byteIndex + byteCount] = dataSpan[byteIndex + byteCount];

        }
    }
    
    public struct Block
    {
        private long _data;

        public bool Contains(int value)
        {
            value = value & 0xF; // first 4 bits
            // 9 x 4
            // init block with value, 9 times and compare
            return false;
        }
    }
}