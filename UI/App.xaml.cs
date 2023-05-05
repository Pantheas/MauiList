using CodeMonkeys.DependencyInjection;
using CodeMonkeys.DependencyInjection.DryIoC;
using CodeMonkeys.MVVM;

using MauiList.UI.Views;
using MauiList.ViewModels;

namespace MauiList.UI;

public partial class App :
    Application
{
	public App()
	{
		InitializeComponent();


        var container = DryFactory.CreateInstance();


        Infrastructure.Bootstrap.ConfigureContainer(
            container);

        ViewModels.Bootstrap.ConfigureContainer(
            container);

        SetMainPage(
            container);
	}

    private void SetMainPage(
        IDependencyContainer container)
    {
        var viewModel = ViewModelFactory.Resolve<MainViewModel>();

        var shell = new AppShell
        {
            BindingContext = viewModel
        };


        MainPage = shell;
    }
}
