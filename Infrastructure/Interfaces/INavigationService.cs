using CodeMonkeys.MVVM;

namespace MauiList.Infrastructure.Interfaces
{
    public interface INavigationService
    {
        Task ShowAsync<TViewModel>()
            where TViewModel : IViewModel;
    }
}
