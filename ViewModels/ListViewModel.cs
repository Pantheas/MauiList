using CodeMonkeys.MVVM.Attributes;
using CodeMonkeys.MVVM.ViewModels;

using MauiList.Infrastructure.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public override async Task InitializeAsync(
            Infrastructure.Models.List list)
        {
            List = list;


            await base.InitializeAsync(
                list);
        }
    }
}
