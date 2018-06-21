using ProyectoSeminarioCic.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoSeminarioCic.Services
{
    public class DbStartUp
    {

        SQLiteConnection dbConnection;
        public DbStartUp()
        {
            //Create Db and a Connection
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
            //Create all Tables
            dbConnection.CreateTable<Notificacion>();
            //...
        }
        public SQLiteConnection ReturnConnection()
        {
            if (dbConnection != null)
                return dbConnection;
            else
                return null;
        }
    }
}
