using System;
using System.Collections.Generic;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class DictionaryExtensions
    {
        public static bool TryGetValueAs<TResult, TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, out TResult? result) where TResult : class where TValue : class
        {
            dictionary.TryGetValue(key, out var value);
            var (res, ret) = value is TResult tValue ? (tValue, true) : (default, default);
            result = res;
            return ret;
        }
        
        public static bool TryGetValueAs<TResult, TKey, TValue, TIntermediate>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue, TIntermediate> getter, out TResult? result) where TResult : class where TValue : class
        {
            dictionary.TryGetValue(key, out var value);
            var (res, ret) = getter(value) is TResult tValue ? (tValue, true) : (default, default);
            result = res;
            return ret;
        }
    }
}