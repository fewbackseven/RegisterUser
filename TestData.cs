using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.SQLite;
using SQLite;

namespace TestDb
{
    [Activity(Label = "TestData")]
    public class TestData : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        //    // Create your application here
        //    //This might be wrong
        //    DatabaseManager mydata = new DatabaseManager();
        //    mydata.SetContext(this);

        }
    }

    //Create table
    public class DataManagerHelper : SQLiteOpenHelper
    {
        // specifies the database name
        private const string DatabaseName = "myDatabaseName";
        //specifies the database version (increment this number each time you make database related changes)
        private const int DatabaseVersion = 3;

        public DataManagerHelper(Context context)
            : base(context, DatabaseName, null, DatabaseVersion)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            //create database tables
            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS Customer (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            FirstName       TEXT NOT NULL,
                            LastName        TEXT NOT NULL )");

            //create database indexes
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS FIRSTNAME_CUSTOMER ON CUSTOMER (FIRSTNAME)");
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS LASTNAME_CUSTOMER ON CUSTOMER (LASTNAME)");

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            if (oldVersion < 2)
            {
                //perform any database upgrade tasks for versions prior to  version 2              
            }
            if (oldVersion < 3)
            {
                //perform any database upgrade tasks for versions prior to  version 3
            }
        }
    }
    
    //Application class to access or Map the table
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
    }

    //Method to invoke before any database calls
    public class DatabaseUpdates
    {
        private DataManagerHelper _helper;

        public void SetContext(Context context)
        {
            if (context != null)
            {
                _helper = new DataManagerHelper(context);
            }
        }

        public long AddCase(Customer addCust)
        {
            using (var db1 = new SQLiteConnection(_helper.WritableDatabase.Path))
            {
                try
                {
                    return db1.Insert(addCust);
                }
                catch (Exception ex)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return AddCase(addCust);
                    //return 0;
                    //throw new NotImplementedException();
                    //return 0;
                }
            }
        }

        public long DeleteCase(Customer deleteCust)
        {
            using (var db = new SQLiteConnection(_helper.WritableDatabase.Path))
            {
                try
                {
                    return db.Delete(deleteCust);
                }
                catch (Exception ex)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return DeleteCase(deleteCust);
                }
            }
        }

        public long UpdateCustomer(Customer updCust)
        {
            using (var db = new SQLiteConnection(_helper.WritableDatabase.Path))
            {
                try
                {
                    return db.Update(updCust);
                }
                catch (Exception ex)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return UpdateCustomer(updCust);
                }
            }
        }


        //Querying Data
        public int GetTotalOrderCount(string custNo)
        {
            using (var db = new SQLiteConnection(_helper.ReadableDatabase.Path))
            {
                try
                {
                    if (!string.IsNullOrEmpty(custNo))
                    {
                        int count = db.Table<Customer>().Count(c => Convert.ToString(c.Id) == custNo);
                        return count;
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        //retrieve a specific user by querying against their first name
        public Customer GetUser(string firstname)
        {
            using (var database = new SQLiteConnection(_helper.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Customer>().FirstOrDefault(u => u.FirstName == firstname);
                }
                catch (Exception ex)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetUser(firstname);
                }
            }
        }

        public IList<Customer> GetAllCustomers()
        {
            using (var database = new SQLiteConnection(_helper.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Customer>().ToList();
                }
                catch (Exception ex)
                {
                    //exception handling code to go here
                    return null;
                }
            }
        }

    }

}
