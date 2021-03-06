﻿using static ExtensionsAndStuff.ThrowHelper;

namespace ExtensionsAndStuff.HelperClasses.WorkflowHelpers
{
    public sealed class Success<T>
    {
        public Success(T value) => Value = value ?? ThrowArgumentNullException(value, nameof(value));
        public T Value { get; }
    }
}