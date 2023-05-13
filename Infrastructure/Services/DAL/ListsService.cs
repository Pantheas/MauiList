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



        public bool Add(
            List list)
        {
            return _repository.Add(
                list);
        }

        public bool Update(
            List list)
        {
            return _repository.Update(
                list);
        }

        public bool Delete(
            List list)
        {
            return _repository.Delete(
                list);
        }


        public List Get(
            Guid id)
        {
            return _repository.Get(
                id);
        }

        public IEnumerable<List> Get(
            Expression<Func<List, bool>> filter)
        {
            return _repository.Get(
                filter);
        }


        public IEnumerable<Models.List> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
