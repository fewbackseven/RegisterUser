using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace App3
{
    public class myData
    {
        readonly SQLiteAsyncConnection database;
        public myData(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<myDataTable>().Wait();
        }



        public Task<int> SaveItemAsync(myDataTable item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }


        public Task<myDataTable> GetItemAsync(int id)
        {
            return database.Table<myDataTable>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

    }
}
