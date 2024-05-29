using System.ComponentModel;

namespace MaterialSymbolsParser.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
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