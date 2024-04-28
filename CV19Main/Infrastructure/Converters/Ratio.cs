using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using CV19Main.Infrastructure.Converters.Base;

namespace CV19Main.Infrastructure.Converters
{
    internal class Ratio : Converter
    {
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;
        public Ratio()
        {
            
        }

        public Ratio( double multiplyParametr)
        {
            K = multiplyParametr;
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((value is null)) return null;

            var x = System.Convert.ToDouble(value, culture);
            return x * K;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string.IsNullOrEmpty((String)value))) return null;
            var x = System.Convert.ToDouble(value, culture);
            return x / K;
        }
    }
}
