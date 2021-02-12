using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestDb
{
    [Activity(Label = "TestDb", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            
            
            Button Insert = FindViewById<Button>(Resource.Id.InsertButton);
            EditText Name = FindViewById<EditText>(Resource.Id.TextBox);

            Insert.Click += (object sender, EventArgs e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                //DataManagerHelper DataBaseManager = new DataManagerHelper(this)
                //{

                //    //DataBaseManager.OnCreate();
                //    base.OnCreate();
                //};
                
                

                Customer var = new Customer();

                var.FirstName = Name.Text;
                var.LastName = Name.Text;

                //Working code
                DatabaseUpdates ManageDb = new DatabaseUpdates();
                ManageDb.SetContext(this);

                DatabaseUpdates upd = new DatabaseUpdates();

                upd.UpdateCustomer(var);
                Name.Text = "";

               
            };

        }
    }
}
