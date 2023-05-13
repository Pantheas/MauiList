using MauiList.Infrastructure.Models;

using System.Linq.Expressions;

namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface IListsRepository
    {
        bool Add(
            List list);

        bool Update(
            List list);

        bool Delete(
            List list);

        IEnumerable<List> GetAll();

        IEnumerable<List> Get(
            Expression<Func<List, bool>> filter);

        List Get(
            Guid id);
    }
}
