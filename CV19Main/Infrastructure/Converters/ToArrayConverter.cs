using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CV19Main.Infrastructure.Converters
{
    internal class ToArrayConverter : MultiConverter
    {
        public override object Convert(object[] v, Type t, object p, CultureInfo c)
        {
            var collection = new CompositeCollection();
            foreach (var value in v)
            {
                collection.Add(value);
            }

            return collection;
        }

        //public override object[] ConvertBack(object v, Type[] t, object p, CultureInfo c) => v as object[];
    }
}
