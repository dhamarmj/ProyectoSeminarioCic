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
    public class UsuarioViewModel
    {
        SQLiteConnection dbConnection;
        public UsuarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Usuario> GetList()
        {
            return dbConnection.Table<Usuario>().ToList();
        }
        public int Insert(Usuario aUsuario)
        {
            return dbConnection.Insert(aUsuario);
        }
        public int Delete(Usuario aUsuario)
        {
            return dbConnection.Delete(aUsuario);
        }
        public int Update(Usuario aUsuario)
        {
            return dbConnection.Update(aUsuario);
        }
        public Usuario Consult(int Id)
        {
            return dbConnection.Table<Usuario>().FirstOrDefault(x => x.Id_usuario == Id);
        }

    }
}
