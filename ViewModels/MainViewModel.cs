using CodeMonkeys.MVVM;
using CodeMonkeys.MVVM.ViewModels;

using MauiList.Infrastructure.Interfaces;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiList.ViewModels
{
    public class MainViewModel :
        ViewModelBase
    {
        private readonly IListsService _listsService;
        

        public ObservableCollection<ListViewModel> Lists
        {
            get => GetValue<ObservableCollection<ListViewModel>>();
            set => SetValue(value);
        }

        public ListViewModel SelectedList
        {
            get => GetValue<ListViewModel>();
            set => SetValue(value);
        }



        public ICommand ListSelectedCommand { get; }

        public ICommand CreateNewListCommand { get; }


        public MainViewModel(
            IListsService listsService)
        {
            _listsService = listsService;
        }


        public override async Task InitializeAsync()
        {
            var lists = await _listsService.GetAllAsync();
            var listViewModels = new ObservableCollection<ListViewModel>();

            foreach (var list in lists)
            {
                var listViewModel = await ViewModelFactory.ResolveAsync<ListViewModel, Infrastructure.Models.List>(
                    list);

                listViewModels.Add(
                    listViewModel);
            }

            SelectedList = listViewModels.First();
            Lists = listViewModels;


            await base.InitializeAsync();
        }
    }
}
