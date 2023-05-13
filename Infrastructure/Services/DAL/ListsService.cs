using MauiList.Infrastructure.Interfaces.Services;
using MauiList.Infrastructure.Models;

using System.Linq.Expressions;

namespace MauiList.Infrastructure.Services.DAL
{
    public class ListsService :
        IListsService
    {
        private readonly IListsRepository _repository;


        public ListsService(
            IListsRepository repository)
        {
            _repository = repository;
        }



        public async Task AddAsync(
            List list)
        {
            await _repository.AddOrUpdateAsync(
                list);
        }

        public async Task UpdateAsync(
            List list)
        {
            await _repository.AddOrUpdateAsync(
                list);
        }

        public async Task DeleteAsync(
            List list)
        {
            await _repository.DeleteAsync(
                list);
        }


        public async Task<List> GetAsync(
            Guid id)
        {
            return await _repository.GetAsync(
                id);
        }

        public async Task<IEnumerable<List>> GetAsync(
            Expression<Func<List, bool>> filter)
        {
            return await _repository.GetAsync(
                filter);
        }


        public async Task<IEnumerable<Models.List>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
