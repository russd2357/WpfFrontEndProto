using System;
using System.Windows;
using WpfFrontEndProto.Views;
using WpfFrontEndProto.ViewModels;
using Services = WpfFrontEndProto.Services;

using SimpleInjector;
using WpfFrontEndProto;

public static class Program
{
	[STAThread]
	public static void Main()
	{
		var container = Bootstrap();

		Run(container);
	}

	private static Container Bootstrap()
	{
		var container = new Container();

		// Register services
		container.Register<Services.Interfaces.ICurveDataService, Services.CurveDataService>();

		// Register viewmodels
		container.Register<MainViewModel>();
		container.Register<CurveDataViewModel>();

		// Register views
		container.Register<MainWindow>();
		container.Register<CurveDataView>();

		// Register singletons
		container.Register<IViewUtils>(() =>
		{
			return new ViewUtils(container);
		});
	
	container.Verify();

		return container;
	}

	private static void Run(Container container)
	{
		var app = new App();

		var mainWindow = container.GetInstance<MainWindow>();
		app.Run(mainWindow);
	}
}
