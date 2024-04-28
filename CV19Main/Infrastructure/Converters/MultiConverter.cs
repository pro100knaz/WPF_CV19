using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace CV19Main.Infrastructure.Converters
{

    internal abstract class MultiConverter : IMultiValueConverter
     {
         public abstract object Convert(object[] v, Type t, object p, CultureInfo c);

        public virtual object[] ConvertBack(object v, Type[] t, object p, CultureInfo c)
        {
            throw new NotSupportedException("Не поддерживается обратное преобразование");
        }
    }
}
