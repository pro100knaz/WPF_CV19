using CV19Main.Infrastructure.Commands.Base;
using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Wpf;


namespace CV19Main.Infrastructure.Commands
{
    internal class AddAxesCommand : Command
    {

        PlotModel model { get;}
        public AddAxesCommand()
        {
            model = new PlotModel();
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                StartPosition = 0, EndPosition = 2,
                
                //Maximum =1,
                Title = "Y",
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                StartPosition = 0, EndPosition = 1,

                Title = "X",
            });

        }

        public override bool CanExecute(object? parameter) => parameter is PlotView;

        public override void Execute(object? parameter)
        {
            ((PlotView)parameter).Model = model;
        }
    }
}
