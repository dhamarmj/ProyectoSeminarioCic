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
            dbConnection.CreateTable<Boleta>();
            //...
            dbConnection.CreateTable<Charla>();
            //...
            dbConnection.CreateTable<Charla_Usuario>();
            //...
            dbConnection.CreateTable<Comentario>();
            //...
            dbConnection.CreateTable<Evento>();
            //...
            dbConnection.CreateTable<Evento_Usuario>();
            //...
            dbConnection.CreateTable<Notificacion>();
            //...
            dbConnection.CreateTable<Permiso>();
            //...
            dbConnection.CreateTable<Permiso_Usuario>();
            //...
            dbConnection.CreateTable<Pregunta>();
            //...
            dbConnection.CreateTable<Publicacion>();
            //...
            dbConnection.CreateTable<Recurso>();
            //...
            dbConnection.CreateTable<Seminario>();
            //...
            dbConnection.CreateTable<Usuario>();
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
