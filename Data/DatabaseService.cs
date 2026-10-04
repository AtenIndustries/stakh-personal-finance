using SQLite;
using Stakh.Models;
using Stakh.Models.Interfaces;

namespace Stakh.Data
{
    public partial class DatabaseService
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private SQLiteAsyncConnection _db;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private async Task InitAsync()
        {
            if (_db is not null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "stakh.db3");
            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<Balance>();
            await _db.CreateTableAsync<ExpenseRecord>();
            await _db.CreateTableAsync<ExpenseRecordCategory>();
            await _db.CreateTableAsync<ExpenseReport>();
            await _db.CreateTableAsync<Income>();
            await _db.CreateTableAsync<MonthBalance>();
            await _db.CreateTableAsync<ReserveFund>();
            await _db.CreateTableAsync<ReserveFundRecord>();
        }

        public async Task<int> CreateAsync<T>(T entity) where T : IIdentifiable, IAuditable, new()
        {
            await InitAsync();
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _db.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<T> GetAsync<T>(int id) where T : IIdentifiable, IAuditable, new()
        {
            await InitAsync();
            return await _db.Table<T>().FirstAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAllAsync<T>() where T : IIdentifiable, IAuditable, new()
        {
            await InitAsync();
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<int> UpdateAsync<T>(T incoming ) where T : IIdentifiable, IAuditable, new()
        {
            await InitAsync();
            var original = await _db.FindAsync<T>(incoming.Id);
            if (original is null)
                return 0; 
            incoming.CreatedAt = original.CreatedAt;
            incoming.UpdatedAt = DateTime.UtcNow; 
            return await _db.UpdateAsync(incoming);
        }

        public async Task<int> DeleteAsync<T>(int id) where T : IIdentifiable, IAuditable, new()
        {
            await InitAsync();
            var entity = await _db.FindAsync<T>(id);
            if (entity is null)
                return 0;
            return await _db.DeleteAsync(entity);
        }

    }
}