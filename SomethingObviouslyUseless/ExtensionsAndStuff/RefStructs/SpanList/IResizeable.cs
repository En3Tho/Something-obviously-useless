namespace ExtensionsAndStuff.RefStructs.SpanList
{
    internal interface IResizeable<T>
    {
        public void Add(T value);
        T this[int index] { get; }
        T[] ToArray();
        void CopyTo(T[] array, int start);
    }
}