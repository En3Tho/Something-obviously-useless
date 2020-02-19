using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace LearnIntermediateLanguage
{
    public static class OtherExtensions
    {
        public static T[] Copy<T>(this T[] array, int start = 0)
        {
            T[] result = new T[array.Length - start];
            Array.Copy(array, start, result, 0, result.Length);
            return result;
        }
    }

    public static class NullCheckExtensions
    {
        public static void NullCheck<T>(this T value)
            where T : class
        {
            _ = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static void NullCheck<T1, T2>(in this (T1, T2) value)
            where T1 : class where T2 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
        }

        public static void NullCheck<T1, T2, T3>(in this (T1, T2, T3) value)
            where T1 : class where T2 : class where T3 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
        }

        public static void NullCheck<T1, T2, T3, T4>(in this (T1, T2, T3, T4) value)
            where T1 : class where T2 : class where T3 : class where T4 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
        }        

        public static void NullCheck<T1, T2, T3, T4, T5>(in this (T1, T2, T3, T4, T5) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
            _ = value.Item5 ?? throw new ArgumentNullException(nameof(value.Item5));
        }

        public static void NullCheck<T1, T2, T3, T4, T5, T6>(in this (T1, T2, T3, T4, T5, T6) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
            _ = value.Item5 ?? throw new ArgumentNullException(nameof(value.Item5));
            _ = value.Item6 ?? throw new ArgumentNullException(nameof(value.Item6));
        }

        public static void NullCheck<T1, T2, T3, T4, T5, T6, T7>(in this (T1, T2, T3, T4, T5, T6, T7) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class
        {
            _ = value.Item1 ?? throw new ArgumentNullException(nameof(value.Item1));
            _ = value.Item2 ?? throw new ArgumentNullException(nameof(value.Item2));
            _ = value.Item3 ?? throw new ArgumentNullException(nameof(value.Item3));
            _ = value.Item4 ?? throw new ArgumentNullException(nameof(value.Item4));
            _ = value.Item5 ?? throw new ArgumentNullException(nameof(value.Item5));
            _ = value.Item6 ?? throw new ArgumentNullException(nameof(value.Item6));
            _ = value.Item7 ?? throw new ArgumentNullException(nameof(value.Item7));
        }

        public static void NoECheck(this string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentException(nameof(str));
        }

        public static void NoECheck(this string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrEmpty(str2)) throw new ArgumentException(nameof(str2));
        }

        public static void NoECheck(this string str1, string str2, string str3)
        {
            if (string.IsNullOrEmpty(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrEmpty(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrEmpty(str3)) throw new ArgumentException(nameof(str3));         
        }

        public static void NoECheck(this string str1, string str2, string str3, string str4)
        {
            if (string.IsNullOrEmpty(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrEmpty(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrEmpty(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrEmpty(str4)) throw new ArgumentException(nameof(str4));
        }

        public static void NoECheck(this string str1, string str2, string str3, string str4, string str5)
        {
            if (string.IsNullOrEmpty(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrEmpty(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrEmpty(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrEmpty(str4)) throw new ArgumentException(nameof(str4));
            if (string.IsNullOrEmpty(str5)) throw new ArgumentException(nameof(str5));
        }

        public static void NoECheck(this string str1, string str2, string str3, string str4, string str5, string str6)
        {
            if (string.IsNullOrEmpty(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrEmpty(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrEmpty(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrEmpty(str4)) throw new ArgumentException(nameof(str4));
            if (string.IsNullOrEmpty(str5)) throw new ArgumentException(nameof(str5));
            if (string.IsNullOrEmpty(str6)) throw new ArgumentException(nameof(str6));     
        }

        public static void NoECheck(this string str1, string str2, string str3, string str4, string str5, string str6, string str7)
        {
            if (string.IsNullOrEmpty(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrEmpty(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrEmpty(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrEmpty(str4)) throw new ArgumentException(nameof(str4));
            if (string.IsNullOrEmpty(str5)) throw new ArgumentException(nameof(str5));
            if (string.IsNullOrEmpty(str6)) throw new ArgumentException(nameof(str6));
            if (string.IsNullOrEmpty(str7)) throw new ArgumentException(nameof(str7));
        }       

        public static void NoEWSCheck(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException(nameof(str));
        }

        public static void NoEWSCheck(this string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrWhiteSpace(str2)) throw new ArgumentException(nameof(str2));
        }

        public static void NoEWSCheck(this string str1, string str2, string str3)
        {
            if (string.IsNullOrWhiteSpace(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrWhiteSpace(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrWhiteSpace(str3)) throw new ArgumentException(nameof(str3));
        }

        public static void NoEWSCheck(this string str1, string str2, string str3, string str4)
        {
            if (string.IsNullOrWhiteSpace(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrWhiteSpace(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrWhiteSpace(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrWhiteSpace(str4)) throw new ArgumentException(nameof(str4));
        }

        public static void NoEWSCheck(this string str1, string str2, string str3, string str4, string str5)
        {
            if (string.IsNullOrWhiteSpace(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrWhiteSpace(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrWhiteSpace(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrWhiteSpace(str4)) throw new ArgumentException(nameof(str4));
            if (string.IsNullOrWhiteSpace(str5)) throw new ArgumentException(nameof(str5));
        }

        public static void NoEWSCheck(this string str1, string str2, string str3, string str4, string str5, string str6)
        {
            if (string.IsNullOrWhiteSpace(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrWhiteSpace(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrWhiteSpace(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrWhiteSpace(str4)) throw new ArgumentException(nameof(str4));
            if (string.IsNullOrWhiteSpace(str5)) throw new ArgumentException(nameof(str5));
            if (string.IsNullOrWhiteSpace(str6)) throw new ArgumentException(nameof(str6));
        }

        public static void NoEWSCheck(this string str1, string str2, string str3, string str4, string str5, string str6, string str7)
        {
            if (string.IsNullOrWhiteSpace(str1)) throw new ArgumentException(nameof(str1));
            if (string.IsNullOrWhiteSpace(str2)) throw new ArgumentException(nameof(str2));
            if (string.IsNullOrWhiteSpace(str3)) throw new ArgumentException(nameof(str3));
            if (string.IsNullOrWhiteSpace(str4)) throw new ArgumentException(nameof(str4));
            if (string.IsNullOrWhiteSpace(str5)) throw new ArgumentException(nameof(str5));
            if (string.IsNullOrWhiteSpace(str6)) throw new ArgumentException(nameof(str6));
            if (string.IsNullOrWhiteSpace(str7)) throw new ArgumentException(nameof(str7));
        }
    }

    public interface ITypesMarker { }

    public struct Types<T> : ITypesMarker { }

    public struct Types<T1, T2> : ITypesMarker { }

    public struct Types<T1, T2, T3> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4, T5> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4, T5, T6> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4, T5, T6, T7> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4, T5, T6, T7, T8> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ITypesMarker { }

    public struct Types<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ITypesMarker { }

}
