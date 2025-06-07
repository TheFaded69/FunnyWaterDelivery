using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using FunnyWaterDelivery.Common.Extensions;

namespace FunnyWaterDelivery.App.Views.Converters;

public class EnumToStringConverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum element) return element.GetDescription();
        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
    
    public override object ProvideValue(IServiceProvider serviceProvider) => this;
}