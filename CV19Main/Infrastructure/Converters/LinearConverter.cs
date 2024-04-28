using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using CV19Main.Infrastructure.Converters.Base;

namespace CV19Main.Infrastructure.Converters
{
    /// <summary>
    /// Реализация линейного преобразования f(x) = k*x + b
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    internal class LinearConverter : Converter
    {
        [ConstructorArgument("K")]
        public double K { get; set; }
        [ConstructorArgument("B")]

        public double B { get; set; }

        public LinearConverter()
        {
            
        }

        public LinearConverter(double K)
        {
            this.K = K;
        }

        public LinearConverter(double K , double B) : this(K)
        {
            this.B = B;
        }
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
