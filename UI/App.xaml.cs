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


        var bootstrap = new Bootstrap();
        bootstrap.ConfigureContainer();

        SetMainPage();
	}

    private void SetMainPage()
    {
        var viewModel = ViewModelFactory.Resolve<MainViewModel>();

        var shell = new AppShell
        {
            BindingContext = viewModel
        };


        MainPage = shell;
    }
}
