using System;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class StringCheckExtensions
    {
        #region NullOrEmpty

        public static void NoECheck(this string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentException(nameof(str));
        }

        public static void NoECheck(this (string str1, string str2) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
        }

        public static void NoECheck(this (string str1, string str2, string str3) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
        }

        public static void NoECheck(this (string str1, string str2, string str3, string str4) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
        }

        public static void NoECheck(this (string str1, string str2, string str3, string str4, string str5) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) throw new ArgumentException(nameof(tuple.str5));
        }

        public static void NoECheck(this (string str1, string str2, string str3, string str4, string str5, string str6) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) throw new ArgumentException(nameof(tuple.str5));
            if (string.IsNullOrEmpty(tuple.str6)) throw new ArgumentException(nameof(tuple.str6));
        }

        public static void NoECheck(this (string str1, string str2, string str3, string str4, string str5, string str6, string str7) tuple)
        {
            if (string.IsNullOrEmpty(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrEmpty(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrEmpty(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrEmpty(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
            if (string.IsNullOrEmpty(tuple.str5)) throw new ArgumentException(nameof(tuple.str5));
            if (string.IsNullOrEmpty(tuple.str6)) throw new ArgumentException(nameof(tuple.str6));
            if (string.IsNullOrEmpty(tuple.str7)) throw new ArgumentException(nameof(tuple.str7));
        }

        #endregion

        #region NullOrWhiteSpace

        public static void NoEWSCheck(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException(nameof(str));
        }

        public static void NoEWSCheck(this (string str1, string str2) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
        }

        public static void NoEWSCheck(this (string str1, string str2, string str3) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
        }

        public static void NoEWSCheck(this (string str1, string str2, string str3, string str4) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
        }

        public static void NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) throw new ArgumentException(nameof(tuple.str5));
        }

        public static void NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5, string str6) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) throw new ArgumentException(nameof(tuple.str5));
            if (string.IsNullOrWhiteSpace(tuple.str6)) throw new ArgumentException(nameof(tuple.str6));
        }

        public static void NoEWSCheck(this (string str1, string str2, string str3, string str4, string str5, string str6, string str7) tuple)
        {
            if (string.IsNullOrWhiteSpace(tuple.str1)) throw new ArgumentException(nameof(tuple.str1));
            if (string.IsNullOrWhiteSpace(tuple.str2)) throw new ArgumentException(nameof(tuple.str2));
            if (string.IsNullOrWhiteSpace(tuple.str3)) throw new ArgumentException(nameof(tuple.str3));
            if (string.IsNullOrWhiteSpace(tuple.str4)) throw new ArgumentException(nameof(tuple.str4));
            if (string.IsNullOrWhiteSpace(tuple.str5)) throw new ArgumentException(nameof(tuple.str5));
            if (string.IsNullOrWhiteSpace(tuple.str6)) throw new ArgumentException(nameof(tuple.str6));
            if (string.IsNullOrWhiteSpace(tuple.str7)) throw new ArgumentException(nameof(tuple.str7));
        }

        #endregion
    }
}
