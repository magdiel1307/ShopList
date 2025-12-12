using ShopList.Gui.Persistence.Configuration;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopList.Gui.Models;

namespace ShopList.Gui.Persistence
{
    public class ShopListDatabase
    {
        private SQLiteAsyncConnection?_connection;

        private async Task InitAsync()
        {
            if (_connection != null)
            {
                return;
            }

            _connection = 
                new SQLiteAsyncConnection
                (Constans.DatabasePath,
                 Constans.Flags);

            await _connection.CreateTableAsync<Item>();

        }
        public async Task<int> SaveItemAsync(Item item)
        {
            await InitAsync();
            return await _connection!.InsertAsync(item);
        }

        public  async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            await InitAsync();
            return await _connection!.Table<Item>().
                ToListAsync();
        }
        public async Task<int> RemoteItemAsync( Item item)
        {
            await InitAsync();
            return await _connection!.DeleteAsync(item);

        }
    }
}
