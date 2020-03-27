namespace Benchmarks.Classes
{
    public static class GenericTests
    {
        public static int GetValue<T>()
        {
            if (typeof(T) == typeof(int))
                return 0;
            if (typeof(T) == typeof(string))
                return 1;
            return 2;
        }
    }
}