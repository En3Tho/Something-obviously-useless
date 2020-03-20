namespace ExtensionsAndStuff.HelperClasses.WorkflowHelpers
{
    public class Error<T>
    {
        public Error(T value) => Value = value ?? ThrowHelper.ThrowArgumentNullException(value, nameof(value));
        public T Value { get; }
    }
}