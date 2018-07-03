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
    public class Evento_UsuarioViewModel
    {
        SQLiteConnection dbConnection;
        public Evento_UsuarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Evento_Usuario> GetList()
        {
            return dbConnection.Table<Evento_Usuario>().ToList();
        }
        public int Insert(Evento_Usuario aEvento_Usuario)
        {
            return dbConnection.Insert(aEvento_Usuario);
        }
        public int Delete(Evento_Usuario aEvento_Usuario)
        {
            return dbConnection.Delete(aEvento_Usuario);
        }
        public int Update(Evento_Usuario aEvento_Usuario)
        {
            return dbConnection.Update(aEvento_Usuario);
        }
        public Evento_Usuario Consult(int Id)
        {
            return dbConnection.Table<Evento_Usuario>().FirstOrDefault(x => x.Id_evento_usuario == Id);
        }

    }
}
