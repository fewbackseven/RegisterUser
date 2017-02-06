using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UserName.Text = "";
            PassWord.Text = "";
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {

            //var l1 = UserName.Text;
            //var l2 = PassWord.Text;

            //var s = new { Name= l1, Password=l2 };
            myDataTable dt = new myDataTable();
            dt.Name = UserName.Text;
            dt.PassWord = PassWord.Text;
            await App.Database.SaveItemAsync(dt);
            await Navigation.PushAsync(new NewPage1());
        }

    }
}
