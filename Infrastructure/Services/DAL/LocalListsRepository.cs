using LiteDB;

using MauiList.Infrastructure.Interfaces.Services;
using MauiList.Infrastructure.Models;

using System.Linq.Expressions;

namespace MauiList.Infrastructure.Services.DAL
{
    public class LocalListsRepository :
        IListsRepository
    {
        private readonly IFileSystemService _fileSystemService;
        
        
        public LocalListsRepository(
            IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }


        public bool Add(
            List list)
        {
            using var database = GetDatabase();

            var collection = database.GetCollection<List>();

            var id = collection.Insert(
                list);
            
            EnsureIndex(
                collection);


            return id.AsGuid != Guid.Empty;
        }


        public bool Update(
            List list)
        {
            using var database = GetDatabase();

            var collection = database.GetCollection<List>();

            bool updated = collection.Update(
                list);

            EnsureIndex(
                collection);


            return updated;
        }


        public bool Delete(
            List list)
        {
            using var database = GetDatabase();

            var collection = database.GetCollection<List>();
            
            bool deleted = collection.Delete(
                list.ID);
            
            EnsureIndex(
                collection);


            return deleted;
        }


        public IEnumerable<List> GetAll()
        {
            using var database = GetDatabase();


            return database.GetCollection<List>()
                .FindAll();
        }


        public List Get(
            Guid id)
        {
            using var database = GetDatabase();


            return database.GetCollection<List>()
                .FindById(id);
        }

        public IEnumerable<List> Get(
            Expression<Func<List, bool>> filter)
        {
            using var database = GetDatabase();


            return database.GetCollection<List>()
                .Find(filter);
        }



        private ILiteDatabase GetDatabase()
        {
            var connectionString = new ConnectionString()
            {
                Filename = _fileSystemService.DatabaseFilePath,
                Connection = ConnectionType.Shared
            };


            return new LiteDatabase(
                connectionString);
        }

        private static void EnsureIndex(
            ILiteCollection<List> collection)
        {
            if (collection == null)
            {
                return;
            }


            collection.EnsureIndex<Guid>(
                list => list.ID,
                unique: true);
        }
    }
}
