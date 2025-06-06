using System.ComponentModel;

namespace FunnyWaterDelivery.Common.Extensions;

public static class EnumExtension
{
    /// <summary>
    /// Получает Description элемента перечисления
    /// </summary>
    /// <param name="enumElement">элемент перечисления</param>
    public static string GetDescription(this Enum enumElement)
    {
        var type = enumElement.GetType();
        var memInfo = type.GetMember(enumElement.ToString());
        
        if (memInfo.Length <= 0) 
            return enumElement.ToString();
        
        var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attrs.Length > 0 
            ? ((DescriptionAttribute)attrs[0]).Description 
            : enumElement.ToString();
    }
}