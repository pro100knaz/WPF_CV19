using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CV19Main.Infrastructure.Converters
{
    internal class ParametricMultipliValueConverter : Freezable, IValueConverter
    {
        #region readonly Value : double - Прибавляемое значение

        ///<summary>  Прибавляемое значение </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(ParametricMultipliValueConverter),
                new PropertyMetadata(1.0));



        ///<summary>  Прибавляемое значение </summary>
        //[Category("")]
        [Description("summary")]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion
        public object Convert(object v, Type t, object p, CultureInfo c)
        {
            var value = System.Convert.ToDouble(v,c);
            return value * Value;
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            var value = System.Convert.ToDouble(v, c);
            return value / Value;
        }

        protected override Freezable CreateInstanceCore()
        {
            return new ParametricMultipliValueConverter() { Value = Value };
        }
    }
}
