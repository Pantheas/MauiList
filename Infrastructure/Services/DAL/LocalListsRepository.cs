using MauiList.Infrastructure.Interfaces.Services;
using MauiList.Infrastructure.Models;

using SQLite;

using System.Linq.Expressions;

namespace MauiList.Infrastructure.Services.DAL
{
    public class LocalListsRepository :
        IListsRepository
    {
        private const SQLiteOpenFlags sqliteOpenFlags =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache |
            // the file is encrypted and inaccessible while the device is locked.
            SQLiteOpenFlags.ProtectionComplete;



        private readonly IFileSystemService _fileSystemService;
        private SQLiteAsyncConnection _database;
        
        
        public LocalListsRepository(
            IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }


        public async Task<bool> AddOrUpdateAsync(
            List list)
        {
            await EnsureDatabaseConnectionAsync();


            return await _database.InsertOrReplaceAsync(
                list) >= 1;
        }

        public async Task<bool> DeleteAsync(
            List list)
        {
            await EnsureDatabaseConnectionAsync();


            return await _database.DeleteAsync(
                list) >= 1;
        }


        public async Task<IEnumerable<List>> GetAllAsync()
        {
            await EnsureDatabaseConnectionAsync();


            return await _database.Table<List>()
                .ToListAsync();
        }


        public async Task<List> GetAsync(
            Guid id)
        {
            await EnsureDatabaseConnectionAsync();


            return await _database.GetAsync<List>(
                id);
        }

        public async Task<IEnumerable<List>> GetAsync(
            Expression<Func<List, bool>> filter)
        {
            await EnsureDatabaseConnectionAsync();


            return await _database
                .Table<List>()
                .Where(filter)
                .ToListAsync();
        }


        private async Task EnsureDatabaseConnectionAsync()
        {
            if (_database is not null)
            {
                return;
            }


            _database = new SQLiteAsyncConnection(
                _fileSystemService.DatabaseFilePath,
                sqliteOpenFlags);

            await _database.CreateTableAsync<Models.List>();
            await _database.CreateTableAsync<Models.ListEntry>();
        }
    }
}
