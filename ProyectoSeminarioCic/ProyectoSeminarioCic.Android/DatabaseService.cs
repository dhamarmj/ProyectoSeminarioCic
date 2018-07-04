using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProyectoSeminarioCic.Droid;
using ProyectoSeminarioCic.Services;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace ProyectoSeminarioCic.Droid
{
    public class DatabaseService : IDBInterface
    {
        SQLiteConnection IDBInterface.CreateConnection()
        {
            var sqliteFilename = "SeminarioC.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) 
            File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection (plat, path);
            // Return the database connection 
            return conn;
        }

    }
}