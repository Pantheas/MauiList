using CodeMonkeys.DependencyInjection;
using CodeMonkeys.DependencyInjection.DryIoC;
using CodeMonkeys.MVVM;

using MauiList.Infrastructure.Interfaces.Services;
using MauiList.UI.Services;

namespace MauiList.UI
{
    internal class Bootstrap
    {
        private readonly IDependencyContainer _container;


        internal Bootstrap()
        {
            _container = DryFactory.CreateInstance();
        }


        internal void ConfigureContainer()
        {
            _container.RegisterType<IFileSystemService, FileSystemService>();
            _container.RegisterType<IPopupService, PopupService>();


            Infrastructure.Bootstrap.ConfigureContainer(
                _container);

            ViewModels.Bootstrap.ConfigureContainer(
                _container);
        }
    }
}
