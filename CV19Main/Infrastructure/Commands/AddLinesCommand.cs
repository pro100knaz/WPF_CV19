using OxyPlot.Wpf;
using CV19Main.Infrastructure.Commands.Base;

namespace CV19Main.Infrastructure.Commands
{
    internal class AddLinesCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            if (parameter is PlotView plotView)
            {
                return plotView.Model != null;
            }

            return false;

        }


        public override void Execute(object? parameter)
        {
           
        }
    }
}
