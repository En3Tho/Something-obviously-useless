namespace AutoDecoratorGenerator
{
    internal static class RawSources
    {
        public const string DecorateAttribute = @"
using System;

namespace AutoDecoratorGenerator
{
    /// <summary>
    /// Placed on a field of a class or struct to indicate a decoration base
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class DecorateAttribute : Attribute { }
}
";

        public const string OverrideAttribute = @"
using System;

namespace AutoDecoratorGenerator
{
    /// <summary>
    /// Indicates that a Method or a Property with such name and signature is manually overriden and should not be auto generated.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class OverrideAttribute : Attribute { }
}
";

        public const string DecorateAttributeName = nameof(AutoDecoratorGenerator) + "." + nameof(DecorateAttribute);
        public const string OverrideAttributeName = nameof(AutoDecoratorGenerator) + "." + nameof(OverrideAttribute);
    }
}