using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.CollectionsToValueTupleExtensions
{
    internal readonly ref struct ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>
    {
        public readonly TResult1[] Result1;
        public readonly TResult2[] Result2;
        public readonly TResult3[] Result3;
        public readonly TResult4[] Result4;
        public readonly TResult5[] Result5;
        public readonly TResult6[] Result6;
        public readonly TResult7[] Result7;
        private readonly Func<TSource, TResult1> _mapper1;
        private readonly Func<TSource, TResult2> _mapper2;
        private readonly Func<TSource, TResult3> _mapper3;
        private readonly Func<TSource, TResult4> _mapper4;
        private readonly Func<TSource, TResult5> _mapper5;
        private readonly Func<TSource, TResult6> _mapper6;
        private readonly Func<TSource, TResult7> _mapper7;

        public ArrayMapper(int count, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6, Func<TSource, TResult7> mapper7)
        {
            (_mapper1, _mapper2, _mapper3, _mapper4, _mapper5, _mapper6, _mapper7) = (mapper1, mapper2, mapper3, mapper4, mapper5, mapper6, mapper7);
            (Result1, Result2, Result3, Result4, Result5, Result6, Result7) =
                (new TResult1[count], new TResult2[count], new TResult3[count], new TResult4[count], new TResult5[count], new TResult6[count], new TResult7[count]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Map(ref TSource value, int index)
        {
            Result1[index] = _mapper1(value);
            Result2[index] = _mapper2(value);
            Result3[index] = _mapper3(value);
            Result4[index] = _mapper4(value);
            Result5[index] = _mapper5(value);
            Result6[index] = _mapper6(value);
            Result7[index] = _mapper7(value);
        }
    }
    
    internal readonly ref struct ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>
    {
        public readonly TResult1[] Result1;
        public readonly TResult2[] Result2;
        public readonly TResult3[] Result3;
        public readonly TResult4[] Result4;
        public readonly TResult5[] Result5;
        public readonly TResult6[] Result6;
        private readonly Func<TSource, TResult1> _mapper1;
        private readonly Func<TSource, TResult2> _mapper2;
        private readonly Func<TSource, TResult3> _mapper3;
        private readonly Func<TSource, TResult4> _mapper4;
        private readonly Func<TSource, TResult5> _mapper5;
        private readonly Func<TSource, TResult6> _mapper6;

        public ArrayMapper(int count, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5, Func<TSource, TResult6> mapper6)
        {
            (_mapper1, _mapper2, _mapper3, _mapper4, _mapper5, _mapper6) = (mapper1, mapper2, mapper3, mapper4, mapper5, mapper6);
            (Result1, Result2, Result3, Result4, Result5, Result6) = (new TResult1[count], new TResult2[count], new TResult3[count], new TResult4[count], new TResult5[count], new TResult6[count]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Map(ref TSource value, int index)
        {
            Result1[index] = _mapper1(value);
            Result2[index] = _mapper2(value);
            Result3[index] = _mapper3(value);
            Result4[index] = _mapper4(value);
            Result5[index] = _mapper5(value);
            Result6[index] = _mapper6(value);
        }
    }
    
    internal readonly ref struct ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>
    {
        public readonly TResult1[] Result1;
        public readonly TResult2[] Result2;
        public readonly TResult3[] Result3;
        public readonly TResult4[] Result4;
        public readonly TResult5[] Result5;
        private readonly Func<TSource, TResult1> _mapper1;
        private readonly Func<TSource, TResult2> _mapper2;
        private readonly Func<TSource, TResult3> _mapper3;
        private readonly Func<TSource, TResult4> _mapper4;
        private readonly Func<TSource, TResult5> _mapper5;

        public ArrayMapper(int count, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4,
            Func<TSource, TResult5> mapper5)
        {
            (_mapper1, _mapper2, _mapper3, _mapper4, _mapper5) = (mapper1, mapper2, mapper3, mapper4, mapper5);
            (Result1, Result2, Result3, Result4, Result5) = (new TResult1[count], new TResult2[count], new TResult3[count], new TResult4[count], new TResult5[count]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Map(ref TSource value, int index)
        {
            Result1[index] = _mapper1(value);
            Result2[index] = _mapper2(value);
            Result3[index] = _mapper3(value);
            Result4[index] = _mapper4(value);
            Result5[index] = _mapper5(value);
        }
    }
    
    internal readonly ref struct ArrayMapper<TSource, TResult1, TResult2, TResult3, TResult4>
    {
        public readonly TResult1[] Result1;
        public readonly TResult2[] Result2;
        public readonly TResult3[] Result3;
        public readonly TResult4[] Result4;
        private readonly Func<TSource, TResult1> _mapper1;
        private readonly Func<TSource, TResult2> _mapper2;
        private readonly Func<TSource, TResult3> _mapper3;
        private readonly Func<TSource, TResult4> _mapper4;

        public ArrayMapper(int count, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3, Func<TSource, TResult4> mapper4)
        {
            (_mapper1, _mapper2, _mapper3, _mapper4) = (mapper1, mapper2, mapper3, mapper4);
            (Result1, Result2, Result3, Result4) = (new TResult1[count], new TResult2[count], new TResult3[count], new TResult4[count]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Map(ref TSource value, int index)
        {
            Result1[index] = _mapper1(value);
            Result2[index] = _mapper2(value);
            Result3[index] = _mapper3(value);
            Result4[index] = _mapper4(value);
        }
    }
    
    internal readonly ref struct ArrayMapper<TSource, TResult1, TResult2, TResult3>
    {
        public readonly TResult1[] Result1;
        public readonly TResult2[] Result2;
        public readonly TResult3[] Result3;
        private readonly Func<TSource, TResult1> _mapper1;
        private readonly Func<TSource, TResult2> _mapper2;
        private readonly Func<TSource, TResult3> _mapper3;

        public ArrayMapper(int count, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2, Func<TSource, TResult3> mapper3)
        {
            (_mapper1, _mapper2, _mapper3) = (mapper1, mapper2, mapper3);
            (Result1, Result2, Result3) = (new TResult1[count], new TResult2[count], new TResult3[count]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Map(ref TSource value, int index)
        {
            Result1[index] = _mapper1(value);
            Result2[index] = _mapper2(value);
            Result3[index] = _mapper3(value);
        }
    }
    
    internal readonly ref struct ArrayMapper<TSource, TResult1, TResult2>
    {
        public readonly TResult1[] Result1;
        public readonly TResult2[] Result2;
        private readonly Func<TSource, TResult1> _mapper1;
        private readonly Func<TSource, TResult2> _mapper2;

        public ArrayMapper(int count, Func<TSource, TResult1> mapper1, Func<TSource, TResult2> mapper2)
        {
            (_mapper1, _mapper2) = (mapper1, mapper2);
            (Result1, Result2) = (new TResult1[count], new TResult2[count]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Map(ref TSource value, int index)
        {
            Result1[index] = _mapper1(value);
            Result2[index] = _mapper2(value);
        }
    }
}