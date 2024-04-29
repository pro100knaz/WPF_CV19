using CV19Main.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CV19Main
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static bool IsDesignMode
		{
			get;
			private set;
		} = true;

		protected override void OnStartup(StartupEventArgs e)
		{
			IsDesignMode = false;
			base.OnStartup(e);
		}

	}
	
}
