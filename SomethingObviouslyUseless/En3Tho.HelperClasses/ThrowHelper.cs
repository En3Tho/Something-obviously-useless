using System;
using System.Diagnostics.CodeAnalysis;

namespace En3Tho.HelperClasses
{
    public static class ThrowHelper
    {
        public static void ThrowArgumentException(string paramName) => throw new ArgumentException("", paramName);
        [return: NotNull] public static T ThrowArgumentException<T>(T value, string paramName) => throw new ArgumentException("", paramName);
        public static void ThrowArgumentException(string message, string paramName) => throw new ArgumentException(message, paramName);
        [return: NotNull] public static T ThrowArgumentException<T>(T value, string message, string paramName) => throw new ArgumentException(message, paramName);
        public static void ThrowArgumentNullException(string paramName) => throw new ArgumentNullException(paramName);
        [return: NotNull] public static T ThrowArgumentNullException<T>(T value, string paramName) => throw new ArgumentNullException(paramName);
        public static void ThrowArgumentOutOfRangeException(string paramName) => throw new ArgumentOutOfRangeException(paramName);
        [return: NotNull] public static T ThrowArgumentOutOfRangeException<T>(T value, string paramName) => throw new ArgumentOutOfRangeException(paramName);
        public static void ThrowInvalidOperationException(string message) => throw new InvalidOperationException(message);
        [return: NotNull] public static T ThrowInvalidOperationException<T>(T value, string message) => throw new InvalidOperationException(message);
        public static void ThrowException(Exception ex) => throw ex;
        [return: NotNull] public static T ThrowException<T>(Exception ex) => throw ex;
    }
}