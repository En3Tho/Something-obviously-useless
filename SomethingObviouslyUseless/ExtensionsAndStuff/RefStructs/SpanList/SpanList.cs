using System;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    public ref struct SpanList<T> where T : class
    {
        public Span<T> Span { get; }
        public int Count { get; private set; }
        private IResizeable<T> _resizeable;
        private readonly ArrayResizePolicy _policy;

        public SpanList(Span<T> span, ArrayResizePolicy policy)
        {
            Span = span;
            Count = 0;
            _policy = policy;
            _resizeable = null;
        }
        
        public void Add(T value)
        {
            AddInternal(value);
        }

        public T this[int index]
        {
            get
                => index < Span.Length ? Span[index] : _resizeable[index - Span.Length];
        }
        
        private void AddInternal(T value)
        {
            if (Count < Span.Length)
                Span[Count] = value;
            else if (_resizeable != null)
                _resizeable.Add(value);
            else
                CreateAndAddToResizeable(value);

            Count++;
        }

        private void CreateAndAddToResizeable(T value)
        {
            _resizeable = _policy switch
            {
                ArrayResizePolicy.Jagged => new JaggedArrayResizeable<T>(),
                ArrayResizePolicy.List => new SimpleArrayResizeable<T>(),
                _ => throw new InvalidOperationException("Non resizeable policy is chosen")
            };
            _resizeable.Add(value);
        }
    }
}