using System;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class StringCheckExtensions
    {
#region NullOrEmpty

        public static string NoECheck(this string str)
        {
            if (string.IsNullOrEmpty(str)) ThrowHelper.ThrowArgumentNullException(nameof(str));
            return str;
        }

        public static (string, string) NoECheck(this (string str1, string str2) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            return tuple;
        }

        public static (string, string, string) NoECheck(this (string str1, string str2, string str3) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            return tuple;
        }

        public static (string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            return tuple;
        }

        public static (string, string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4, string str5) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str5));
            return tuple;
        }

        public static (string, string, string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4, string str5, string str6) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str5));
            if (string.IsNullOrEmpty(tuple.str6)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str6));
            return tuple;
        }

        public static (string, string, string, string, string, string, string) NoECheck(this (string str1, string str2, string str3, string str4, string str5, string str6, string str7) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str5));
            if (string.IsNullOrEmpty(tuple.str6)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str6));
            if (string.IsNullOrEmpty(tuple.str7)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str7));
            return tuple;
        }

#endregion

#region NullOrWhiteSpace

        public static string NoEWSCheck(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) ThrowHelper.ThrowArgumentNullException(nameof(str));
            return str;
        }

        public static (string, string) NoEWSCheck(this (string str1, string str2) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            return tuple;
        }

        public static (string, string, string) NoEWSCheck(this (string str1, string str2, string str3) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            return tuple;
        }

        public static (string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            return tuple;
        }

        public static (string, string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str5));
            return tuple;
        }

        public static (string, string, string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5, string str6) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str5));
            if (string.IsNullOrWhiteSpace(tuple.str6)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str6));
            return tuple;
        }

        public static (string, string, string, string, string, string, string) NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5, string str6, string str7) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str5));
            if (string.IsNullOrWhiteSpace(tuple.str6)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str6));
            if (string.IsNullOrWhiteSpace(tuple.str7)) ThrowHelper.ThrowArgumentNullException(nameof(tuple.str7));
            return tuple;
        }

#endregion
    }
}