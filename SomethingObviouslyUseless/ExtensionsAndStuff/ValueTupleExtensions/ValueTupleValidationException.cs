using System;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public class ValueTupleValidationException : Exception
    {
        public static void Throw(string message)
        {
            throw new ValueTupleValidationException(message);
        }

        public ValueTupleValidationException(string message) : base(message)
        {
        }

        public ValueTupleValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValueTupleValidationException()
        {
        }
    }
}
