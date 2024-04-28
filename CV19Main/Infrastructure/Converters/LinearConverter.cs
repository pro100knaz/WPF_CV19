using System.Globalization;
using CV19Main.Infrastructure.Converters.Base;

namespace CV19Main.Infrastructure.Converters
{
    /// <summary>
    /// Реализация линейного преобразования f(x) = k*x + b
    /// </summary>
    class LinearConverter : Converter
    {
        public double K { get; set; } = 1;
        public double B { get; set; } = 0;
        public LinearConverter() { }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var x = System.Convert.ToDouble(value , culture);
            return K *x + B;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var y = System.Convert.ToDouble(value, culture);

            return (y - B) / K;
        }
    }
}
