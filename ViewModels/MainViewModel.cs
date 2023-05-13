using CodeMonkeys.MVVM;
using CodeMonkeys.MVVM.Commands;
using CodeMonkeys.MVVM.ViewModels;

using MauiList.Infrastructure.Interfaces.Services;
using MauiList.Infrastructure.Models;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiList.ViewModels
{
    public class MainViewModel :
        ViewModelBase
    {
        private readonly IListsService _listsService;
        private readonly IPopupService _popupService;
        

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



        public ICommand CreateNewListCommand { get; }


        public MainViewModel(
            IListsService listsService
            , IPopupService popupService)
        {
            _listsService = listsService;
            _popupService = popupService;


            CreateNewListCommand = new AsyncCommand(
                CreateNewListAsync);
        }


        public override async Task InitializeAsync()
        {
            var lists = _listsService.GetAll();
            var listViewModels = new ObservableCollection<ListViewModel>();

            foreach (var list in lists)
            {
                var listViewModel = await ViewModelFactory.ResolveAsync<ListViewModel, Infrastructure.Models.List>(
                    list);

                listViewModels.Add(
                    listViewModel);
            }

            SelectedList = listViewModels.FirstOrDefault();
            Lists = listViewModels;


            await base.InitializeAsync();
        }


        private async Task CreateNewListAsync()
        {
            string listName = await _popupService.ShowPromptAsync(
                "title",
                "message",
                "ok",
                "cancel");


            var list = new List
            {
                Name = listName,
            };

            _listsService.Add(
                list);
        }
    }
}
