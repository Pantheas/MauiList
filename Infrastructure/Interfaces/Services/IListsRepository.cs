using MauiList.Infrastructure.Models;

using System.Linq.Expressions;

namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface IListsRepository
    {
        Task<bool> AddOrUpdateAsync(
            List list);

        Task<bool> DeleteAsync(
            List list);

        Task<IEnumerable<List>> GetAllAsync();

        Task<IEnumerable<List>> GetAsync(
            Expression<Func<List, bool>> filter);

        Task<List> GetAsync(
            Guid id);
    }
}
