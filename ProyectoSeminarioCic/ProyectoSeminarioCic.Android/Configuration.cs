using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly : Dependency(typeof(ProyectoSeminarioCic.Droid.Configuration))]

namespace ProyectoSeminarioCic.Droid
{
    public class Configuration : ProyectoSeminarioCic.Services.IConfiguration
    {
        private string Directorio;
        private ISQLitePlatform Plataforma;
        

        public string directorio
        {
            get
            {
                if (string.IsNullOrEmpty(Directorio))
                {
                    Directorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return Directorio;
            }
        }
    
           public ISQLitePlatform plataforma
        {
            get
            {
                if (Plataforma==null)
                {
                    Plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return Plataforma;
            }
        }
    }
}