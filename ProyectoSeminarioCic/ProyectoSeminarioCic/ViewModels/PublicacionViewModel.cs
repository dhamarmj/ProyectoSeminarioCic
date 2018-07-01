using ProyectoSeminarioCic.Services;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ProyectoSeminarioCic.Models;
using System.Collections.ObjectModel;

namespace ProyectoSeminarioCic.ViewModels
{
    public class PublicacionViewModel
    {
        SQLiteConnection dbConnection;
        public PublicacionViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Publicacion> GetList()
        {
            return dbConnection.Table<Publicacion>().ToList();
        }
        public int Insert(Publicacion aPublicacion)
        {
            return dbConnection.Insert(aPublicacion);
        }
        public int Delete(Publicacion aPublicacion)
        {
            return dbConnection.Delete(aPublicacion);
        }
        public int Update(Publicacion aPublicacion)
        {
            return dbConnection.Update(aPublicacion);
        }
        public Publicacion Consult(int Id)
        {
            return dbConnection.Table<Publicacion>().FirstOrDefault(x => x.Id_publicacion == Id);
        }

    }
}
