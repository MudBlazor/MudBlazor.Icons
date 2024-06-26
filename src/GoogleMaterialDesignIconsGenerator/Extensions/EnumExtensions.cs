﻿using System.ComponentModel;

namespace GoogleMaterialDesignIconsGenerator.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var type = value.GetType();

        var memberInfo = type.GetMember(value.ToString());

        if (memberInfo is { Length: > 0 })
        {
            if (memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
        }

        return value.ToString();
    }
}