namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        public static (T, T, T, T, T, T, T) Reverse<T>(this (T, T, T, T, T, T, T) tuple)
            => (tuple.Item7, tuple.Item6, tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);
        
        public static (T, T, T, T, T, T) Reverse<T>(this (T, T, T, T, T, T) tuple)
            => (tuple.Item6, tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);
        
        public static (T, T, T, T, T) Reverse<T>(this (T, T, T, T, T) tuple)
            => (tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);
        
        public static (T, T, T, T) Reverse<T>(this (T, T, T, T) tuple)
            => (tuple.Item4, tuple.Item3, tuple.Item2, tuple.Item1);
        
        public static (T, T, T) Reverse<T>(this (T, T, T) tuple)
            => (tuple.Item3, tuple.Item2, tuple.Item1);
        
        public static (T, T) Reverse<T>(this (T, T) tuple)
            => (tuple.Item2, tuple.Item1);
    }
}