using CodeMonkeys.DependencyInjection;
using CodeMonkeys.MVVM;

namespace MauiList.ViewModels
{
    public static class Bootstrap
    {
        public static void ConfigureContainer(
            IDependencyContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(
                    nameof(container));
            }

            ViewModelFactory.Configure(
                container);

            ViewModelFactory.Register<MainViewModel>();
            ViewModelFactory.Register<ListViewModel>();
        }
    }
}
