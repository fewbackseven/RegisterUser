using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using SQLite;
using Greetings;
//using System.Reflection.Emit;
//using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    //public interface IPlatformInfo
    //{
    //    string GetModel();
    //    string GetVersion();
    //}



    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }

    public class GreetingsPage : ContentPage
    {


        public GreetingsPage()
        {


        }
    }
}







//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;

//using Xamarin.Forms;

//namespace App3
//{
//    public class Greetings : ContentPage
//    {
//        public Greetings()
//        {
//            Content = new StackLayout
//            {
//                Children = {
//                    new Label { Text = "Hello Page" }
//                }
//            };
//        }
//    }
//}
