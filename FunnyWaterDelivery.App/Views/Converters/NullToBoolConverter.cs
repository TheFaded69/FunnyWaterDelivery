using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace FunnyWaterDelivery.App.Views.Converters;

[ValueConversion(typeof(object), typeof(bool))]
public class NullToBoolConverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value != null;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;

    public override object ProvideValue(IServiceProvider serviceProvider) => this;
}