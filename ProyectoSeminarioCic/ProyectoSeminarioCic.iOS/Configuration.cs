using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite.Net.Interop;
using System.IO;
using Xamarin.Forms;
[assembly: Dependency(typeof(ProyectoSeminarioCic.iOS.Configuration))]

namespace ProyectoSeminarioCic.iOS
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
                    var dir = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    Directorio = Path.Combine(dir,"..","Library");
                }
                return Directorio;
            }
        }

        public ISQLitePlatform plataforma
        {
            get
            {
                if (Plataforma == null)
                {
                    Plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return Plataforma;
            }
        }
    }
}