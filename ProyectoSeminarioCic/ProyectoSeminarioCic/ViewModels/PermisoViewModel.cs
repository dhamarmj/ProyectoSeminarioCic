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
    public class PermisoViewModel
    {
        SQLiteConnection dbConnection;
        public PermisoViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Permiso> GetList()
        {
            return dbConnection.Table<Permiso>().ToList();
        }
        public int Insert(Permiso aPermiso)
        {
            return dbConnection.Insert(aPermiso);
        }
        public int Delete(Permiso aPermiso)
        {
            return dbConnection.Delete(aPermiso);
        }
        public int Update(Permiso aPermiso)
        {
            return dbConnection.Update(aPermiso);
        }
        public Permiso Consult(int Id)
        {
            return dbConnection.Table<Permiso>().FirstOrDefault(x => x.Id_permiso == Id);
        }

    }
}
