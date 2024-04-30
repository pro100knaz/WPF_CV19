using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CV19Main.Components
{
    /// <summary>
    /// Логика взаимодействия для GaugeIndicator.xaml
    /// </summary>
    public partial class GaugeIndicator
    {
        #region ValueProperty

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(GaugeIndicator),
                new PropertyMetadata(default(double),
                    OnValuePropertyChanged,
                    OnCoerceValue),
                OnValidateValue);

        private static bool OnValidateValue(object value)
        {

            return true;
        }

        private static object OnCoerceValue(DependencyObject d, object basevalue)
        {
            var value = (double)basevalue;
            return Math.Max(0, Math.Min(value, 100));
        }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           //var gauge_indicator = (GaugeIndicator) d;
           //gauge_indicator.ArrowRotator.Angle = (double) e.NewValue;
        }


        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set => SetValue(ValueProperty,value);
        }

        #endregion

        #region readonly Angle : double - Какой-то угол

        ///<summary> Какой-то угол </summary>
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register(
                nameof(Angle),
                typeof(double),
                typeof(GaugeIndicator),
                new PropertyMetadata(default(double)));



        ///<summary> Какой-то угол </summary>
        //[Category("")]
        [Description("Какой-то угол")]
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        #endregion
        public GaugeIndicator()
        {
            InitializeComponent();
        }
    }
}
