﻿using Module.Core.EnumExtensions;

namespace Module.Core.Tests.EnumExtensions
{
    [EnumExtensions]
    public enum FruitType : byte { Apple, Orange, }

    partial class FruitTypeExtensions { }

    [EnumExtensionsFor(typeof(System.DayOfWeek))]
    public static partial class DayOfWeekExtensions { }
}
