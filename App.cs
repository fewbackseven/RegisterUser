using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App3;


namespace App3
{
    public class App : Application
    {
        
        public App()
        {
            // The root page of your application
            //MainPage = new CodePlusXamlPage();
            MainPage = new NavigationPage(new MainPage());
        }

        static myData database;
        public static myData Database
        {
            get
            {
                if (database == null)
                {
                    database = new myData(DependencyService.Get<IFileHelper>().GetLocalFilePath("UserSQLite.db3"));
                }
                return database;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
















//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Xamarin.Forms;

//namespace App3
//{
//    public class App : Application
//    {
//        public App()
//        {
//            // The root page of your application
//            var content = new ContentPage
//            {
//                Title = "App3",
//                Content = new StackLayout
//                {
//                    VerticalOptions = LayoutOptions.Center,
//                    Children = {
//                        new Label {
//                            HorizontalTextAlignment = TextAlignment.Center,
//                            Text = "Welcome to Xamarin Forms!"
//                        }
//                    }
//                }
//            };

//            MainPage = new NavigationPage(content);
//        }

//        protected override void OnStart()
//        {
//            // Handle when your app starts
//        }

//        protected override void OnSleep()
//        {
//            // Handle when your app sleeps
//        }

//        protected override void OnResume()
//        {
//            // Handle when your app resumes
//        }
//    }
//}
