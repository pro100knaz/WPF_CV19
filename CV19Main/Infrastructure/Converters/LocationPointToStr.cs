using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using CV19Main.Infrastructure.Converters.Base;
using CV19Main.Models;

namespace CV19Main.Infrastructure.Converters
{
    [ValueConversion(typeof(PersonalPoint), typeof(string))]
    [MarkupExtensionReturnType(typeof(LocationPointToStr))]


    internal class LocationPointToStr : Converter
    {
        public override object Convert(object value, Type ty, object p, CultureInfo c)
        {
            if (!(value is PersonalPoint point)) return null;
            return $"Lat:{point.X};Lot:{point.Y}";
        }

        public override object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is string str)) return null;


            var components = str.Split(';');

            var Lat = double.Parse(components[0].Split(':').ToArray()[1]);
            var Lot = double.Parse(components[1].Split(':').ToArray()[1]);
            return new PersonalPoint(Lat, Lot);
        }
    }
}
