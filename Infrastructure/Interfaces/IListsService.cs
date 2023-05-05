namespace MauiList.Infrastructure.Interfaces
{
    public interface IListsService
    {
        public Task<IEnumerable<Models.List>> GetAllAsync();
        
        public Task<Models.List> GetAsync(
            Guid id);
        public Task<Models.List> GetAsync(
            Func<Models.List, bool> filter);

        public Task AddAsync(
            Models.List list);
        public Task UpdateAsync(
            Models.List list);
        public Task DeleteAsync(
            Models.List list);
    }
}
