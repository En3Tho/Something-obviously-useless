namespace En3Tho.ILHelpers
{
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