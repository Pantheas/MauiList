using CodeMonkeys.MVVM;

namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface INavigationService
    {
        Task ShowAsync<TViewModel>()
            where TViewModel : IViewModel;
    }
}
