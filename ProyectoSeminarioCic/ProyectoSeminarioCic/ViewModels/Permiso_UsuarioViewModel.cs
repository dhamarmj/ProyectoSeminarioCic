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
    public class Permiso_UsuarioViewModel
    {
        SQLiteConnection dbConnection;
        public Permiso_UsuarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }
        public List<Permiso_Usuario> GetList()
        {
            return dbConnection.Table<Permiso_Usuario>().ToList();
        }
        public int Insert(Permiso_Usuario aPermiso_Usuario)
        {
            return dbConnection.Insert(aPermiso_Usuario);
        }
        public int Delete(Permiso_Usuario aPermiso_Usuario)
        {
            return dbConnection.Delete(aPermiso_Usuario);
        }
        public int Update(Permiso_Usuario aPermiso_Usuario)
        {
            return dbConnection.Update(aPermiso_Usuario);
        }
        public Permiso_Usuario Consult(int Id)
        {
            return dbConnection.Table<Permiso_Usuario>().FirstOrDefault(x => x.Id_permiso_usuario == Id);
        }

    }
}
