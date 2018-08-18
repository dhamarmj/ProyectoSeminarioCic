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
            try
            {
                dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
                dbConnection.CreateTable<Usuario>();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine(ex.ToString());
            }

            //Create all Tables
            //dbConnection.CreateTable<Seminario>();

            //dbConnection.CreateTable<Comentario>();

            //dbConnection.CreateTable<Recurso>();

            //dbConnection.CreateTable<Publicacion>();

            //dbConnection.CreateTable<Boleta>();

            //dbConnection.CreateTable<Evento>();

            //dbConnection.CreateTable<Pregunta>();

            //dbConnection.CreateTable<Charla_Usuario>();
           
            //dbConnection.CreateTable<Evento_Usuario>();

            //dbConnection.CreateTable<Notificacion>();

            //dbConnection.CreateTable<Permiso_Usuario>();

            //dbConnection.CreateTable<Permiso>();

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
