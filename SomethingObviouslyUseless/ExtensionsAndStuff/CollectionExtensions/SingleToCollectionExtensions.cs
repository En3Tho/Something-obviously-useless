using System.Collections.Generic;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class SingleToCollectionExtensions
    {
        public static T[] AsArray<T>(this T obj) => new [] { obj };

        public static IEnumerable<T> AsEnumerable<T>(this T obj)
        {
            yield return obj;
        }
    }
}