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

    public interface ITypesMarker { }

    public struct Types : ITypesMarker { }

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
