using System.Diagnostics;
using System.Windows.Shapes;
using OxyPlot.Wpf;
using CV19Main.Infrastructure.Commands.Base;
using OxyPlot.Series;
using OxyPlot;

namespace CV19Main.Infrastructure.Commands
{
    internal class AddLinesCommand : Command
    {

        private IEnumerable<DataPoint> _testDataPoints;
        /// <summary>
        /// Тестовый набор данных для визуализации графиков
        /// </summary>
        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _testDataPoints;
            set => _testDataPoints = value;
        }

   
        LineSeries _lineSeries;
        public AddLinesCommand()
        {

            var x = Enumerable.Range(0, 360).ToArray();

            var y = Enumerable.Range(0, 360).Select(i => Math.Sin(i * (Math.PI / 180))).ToArray();

            var combined = x.Zip(y, (xVal, yVal) => new { X = xVal, Y = yVal });

            var combinedList = combined.ToList();

            LineSeries lineSeries = new LineSeries
            {
                Title = "Line Series",
                MarkerType = MarkerType.Circle,
                MarkerSize = 1,
                MarkerStroke = OxyColors.Red,
                MarkerFill = OxyColors.Transparent,
            };
            for (int i = 0; i < x.Count(); i++)
            {
                lineSeries.Points.Add(new DataPoint(x[i], y[i]));
            }

            _lineSeries = lineSeries;

            //LineSeries lineSeries = new LineSeries
            //{
            //    Title = "Line Series",
            //    MarkerType = MarkerType.Circle,
            //    MarkerSize = 1,
            //    MarkerStroke = OxyColors.Red,
            //    MarkerFill = OxyColors.Transparent,
            //};

            //var data_points = new List<DataPoint>((int)(360 / 0.1));

            //for (var x = 0d; x <= 360; x += 0.1)
            //{
            //    const double to_rad = Math.PI / 180;
            //    var y = Math.Sin(x * to_rad);
            //    data_points.Add(new DataPoint(x, y));
            //    lineSeries.Points.Add(new DataPoint(x, y));
            //}
            //_lineSeries = lineSeries;


        }



        public override bool CanExecute(object? parameter)
        {
            
            if (parameter is PlotView plotView)
            {
               
                    return plotView.Model != null;
            }
            return false;

        }



        //private void CreatePoints()
        //{
        //    var data_points = new List<DataPoint>((int)(360 / 0.1));

        //    for (var x = 0d; x <= 360; x += 0.1)
        //    {
        //        const double to_rad = Math.PI / 180;
        //        var y = Math.Sin(x * to_rad);
        //        data_points.Add(new DataPoint(x, y));
        //        lineSeries.A
        //    }

        //    TestDataPoints = data_points;
        //}


        public override void Execute(object? parameter)
        {
            if (parameter is PlotView plotView)
            {
                if (plotView.Model.Series.Count == 0)
                {
                    plotView.Model.Series.Add(_lineSeries);
                }
                else
                {
                    plotView.Model.Series.Clear();
                }
            }
        }
    }
}
