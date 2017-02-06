using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App3
{
    public partial class NewPage1 : ContentPage
    {
        public NewPage1()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            int m1 = 1;
            base.OnAppearing();
            myDataTable dt = new myDataTable();
            dt = await App.Database.GetItemAsync(m1);
            userName.Text = dt.Name;
            passWord.Text = dt.PassWord;
        }
    }
}
