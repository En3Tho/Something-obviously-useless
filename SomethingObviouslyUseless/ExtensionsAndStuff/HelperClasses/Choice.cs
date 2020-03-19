namespace ExtensionsAndStuff.HelperClasses
{
    public abstract class Choice
    {
        public object Value { get; }

        protected Choice(object value) => Value = value ?? ThrowHelper.ThrowArgumentNullException(value, nameof(value));
    }

    public class Choice<T1, T2> : Choice where T1 : notnull where T2 : notnull
    {
        public Choice(T1 value) : base(value) { }
        public Choice(T2 value) : base(value) { }
    }

    public class Choice<T1, T2, T3> : Choice where T1 : notnull where T2 : class where T3 : notnull
    {
        public Choice(T1 value) : base(value) { }
        public Choice(T2 value) : base(value) { }
        public Choice(T3 value) : base(value) { }
    }

    public class Choice<T1, T2, T3, T4> : Choice where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
    {
        public Choice(T1 value) : base(value) { }
        public Choice(T2 value) : base(value) { }
        public Choice(T3 value) : base(value) { }
        public Choice(T4 value) : base(value) { }
    }

    public class Choice<T1, T2, T3, T4, T5> : Choice where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
    {
        public Choice(T1 value) : base(value) { }
        public Choice(T2 value) : base(value) { }
        public Choice(T3 value) : base(value) { }
        public Choice(T4 value) : base(value) { }
        public Choice(T5 value) : base(value) { }
    }
}
