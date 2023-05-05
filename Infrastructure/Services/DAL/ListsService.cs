using MauiList.Infrastructure.Interfaces;
using MauiList.Infrastructure.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiList.Infrastructure.Services.DAL
{
    public class ListsService :
        IListsService
    {
        public Task AddAsync(List list)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(List list)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.List>> GetAllAsync()
        {
            await Task.CompletedTask;


            var list = new Infrastructure.Models.List
            {
                Name = "My first list",
                Entries = new ObservableCollection<Infrastructure.Models.ListEntry>
                {
                    new Infrastructure.Models.ListEntry
                    {
                        Content = "Entry #1",
                        IsChecked = true,
                        CreationDate = DateTime.Now
                    },
                    new Infrastructure.Models.ListEntry
                    {
                        Content = "Entry #2",
                        IsChecked = false,
                        CreationDate = DateTime.Now
                    },
                    new Infrastructure.Models.ListEntry
                    {
                        Content = "Entry #3",
                        IsChecked = false,
                        CreationDate = DateTime.Now
                    }
                },
                CreationDate = DateTime.Now,
            };


            return new List<Models.List>
            {
                list
            };

        }

        public Task<List> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List> GetAsync(Func<List, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(List list)
        {
            throw new NotImplementedException();
        }
    }
}
