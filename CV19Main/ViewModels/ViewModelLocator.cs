using Microsoft.Extensions.DependencyInjection;

namespace CV19Main.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();

    }
}
