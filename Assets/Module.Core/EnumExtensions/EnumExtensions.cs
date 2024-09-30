using System;

namespace Module.Core.EnumExtensions
{
    /// <summary>
    /// Add to any enum that should be extended.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public class EnumExtensionsAttribute : Attribute
    {
    }

    /// <summary>
    /// Add to any static class that should extend an enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EnumExtensionsForAttribute : Attribute
    {
        public Type EnumType { get; }

        public EnumExtensionsForAttribute(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            if (enumType.IsEnum == false)
                throw new InvalidOperationException($"{enumType} is not an enum.");

            EnumType = enumType;
        }
    }
}
