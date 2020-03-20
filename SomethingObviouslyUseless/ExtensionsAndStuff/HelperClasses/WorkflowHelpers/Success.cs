namespace ExtensionsAndStuff.HelperClasses.WorkflowHelpers
{
    public class Success<T>
    {
        public Success(T value) => Value = value ?? ThrowHelper.ThrowArgumentNullException(value, nameof(value));
        public T Value { get; }
    }
}