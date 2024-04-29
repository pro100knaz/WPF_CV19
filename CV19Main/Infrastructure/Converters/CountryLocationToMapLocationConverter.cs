using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Infrastructure.Converters.Base;
using CV19Main.Models;
using MapControl;

namespace CV19Main.Infrastructure.Converters
{
    class CountryLocationToMapLocationConverter : Converter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
                return new Location(0,0);

            PersonalPoint cur = (PersonalPoint)value;
            return  new Location(cur.X,cur.Y);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new PersonalPoint(0, 0);
            return new PersonalPoint(((Location)value).Latitude, ((Location)value).Longitude);
        }
    }
}
