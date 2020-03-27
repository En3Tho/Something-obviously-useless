using static ExtensionsAndStuff.ThrowHelper;

namespace ExtensionsAndStuff.HelperClasses.WorkflowHelpers
{
    public class Error<T>
    {
        public Error(T value) => Value = value ?? ThrowArgumentNullException(value, nameof(value));
        public T Value { get; }
    }
}