using CodeMonkeys.MVVM.Attributes;
using CodeMonkeys.MVVM.Commands;
using CodeMonkeys.MVVM.ViewModels;

using MauiList.Infrastructure.Models;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiList.ViewModels
{
    public class ListViewModel :
        ViewModelBase<Infrastructure.Models.List>
    {
        public Infrastructure.Models.List List
        {
            get => GetValue<Infrastructure.Models.List>();
            set => SetValue(value);
        }


        [DependsOn(nameof(List))]
        public ObservableCollection<ListEntry> Entries =>
            new(List.Entries);

        public string NewEntryContent
        {
            get => GetValue<string>();
            set => SetValue(value);
        }


        public ICommand AddNewEntryCommand { get; }


        public ListViewModel()
        {
            AddNewEntryCommand = new AsyncCommand(
                AddNewListEntry,
                CanAddNewListEntry);
        }


        public override async Task InitializeAsync(
            Infrastructure.Models.List list)
        {
            List = list;


            await base.InitializeAsync(
                list);
        }


        private bool CanAddNewListEntry()
        {
            return string.IsNullOrWhiteSpace(
                NewEntryContent) == false;
        }

        private Task AddNewListEntry()
        {
            var entry = new ListEntry
            {
                Content = NewEntryContent
            };

            Entries.Add(
                entry);


            return Task.CompletedTask;
        }
    }
}
