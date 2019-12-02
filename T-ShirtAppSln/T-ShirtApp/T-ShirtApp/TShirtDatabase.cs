using SQLite;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace T_ShirtApp
{
   public class TShirtDatabase
    {
        readonly SQLiteAsyncConnection database;
        public TShirtDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TShirtItem>().Wait();
        }
        public Task<List<TShirtItem>> GetItemsAsync()
        {
            return database.Table<TShirtItem>().ToListAsync();
        }

        public Task<List<TShirtItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TShirtItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TShirtItem> GetItemAsync(int id)
        {
            return database.Table<TShirtItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TShirtItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TShirtItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
