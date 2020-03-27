using System.Runtime.CompilerServices;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.StringExtensions
{
    public static class ValueTupleStringCheckExtensions
    {
#region NullOrEmpty

        private const string NullOrEmptyMessage = "String is null or empty.";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string NoECheck(this string str, string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(str)) ThrowArgumentException(message, nameof(str));
            return str;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string) NoECheck(this (string str1, string str2) tuple, string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string) NoECheck(this (string str1, string str2, string str3) tuple, string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4) tuple, string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4, string str5) tuple, string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) ThrowArgumentException(message, nameof(tuple.str5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4, string str5, string str6) tuple,
            string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) ThrowArgumentException(message, nameof(tuple.str5));
            if (string.IsNullOrEmpty(tuple.str6)) ThrowArgumentException(message, nameof(tuple.str6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4, string str5, string str6, string str7) tuple,
            string message = NullOrEmptyMessage)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) ThrowArgumentException(message, nameof(tuple.str5));
            if (string.IsNullOrEmpty(tuple.str6)) ThrowArgumentException(message, nameof(tuple.str6));
            if (string.IsNullOrEmpty(tuple.str7)) ThrowArgumentException(message, nameof(tuple.str7));
            return tuple;
        }

#endregion

#region NullOrWhiteSpace

        private const string NullOrEmptyOrWhiteSpaceMessage = "String is null or empty or white space.";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string NoEWSCheck(this string str, string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(str)) ThrowArgumentException(message, nameof(str));
            return str;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string) NoEWSCheck(this (string str1, string str2) tuple, string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string) NoEWSCheck(this (string str1, string str2, string str3) tuple, string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4) tuple, string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5) tuple, string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) ThrowArgumentException(message, nameof(tuple.str5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5, string str6) tuple,
            string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) ThrowArgumentException(message, nameof(tuple.str5));
            if (string.IsNullOrWhiteSpace(tuple.str6)) ThrowArgumentException(message, nameof(tuple.str6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string, string, string, string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5, string str6, string str7) tuple,
            string message = NullOrEmptyOrWhiteSpaceMessage)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowArgumentException(message, nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowArgumentException(message, nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowArgumentException(message, nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowArgumentException(message, nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) ThrowArgumentException(message, nameof(tuple.str5));
            if (string.IsNullOrWhiteSpace(tuple.str6)) ThrowArgumentException(message, nameof(tuple.str6));
            if (string.IsNullOrWhiteSpace(tuple.str7)) ThrowArgumentException(message, nameof(tuple.str7));
            return tuple;
        }

#endregion
    }
}