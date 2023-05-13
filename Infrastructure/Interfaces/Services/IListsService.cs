using System.Linq.Expressions;

namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface IListsService
    {
        public Task<IEnumerable<Models.List>> GetAllAsync();

        public Task<Models.List> GetAsync(
            Guid id);
        public Task<IEnumerable<Models.List>> GetAsync(
            Expression<Func<Models.List, bool>> filter);

        public Task AddAsync(
            Models.List list);
        public Task UpdateAsync(
            Models.List list);
        public Task DeleteAsync(
            Models.List list);
    }
}
