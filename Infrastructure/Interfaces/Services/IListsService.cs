using System.Linq.Expressions;

namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface IListsService
    {
        IEnumerable<Models.List> GetAll();

        Models.List Get(
            Guid id);
        IEnumerable<Models.List> Get(
            Expression<Func<Models.List, bool>> filter);

        bool Add(
            Models.List list);

        bool Update(
            Models.List list);

        bool Delete(
            Models.List list);
    }
}
