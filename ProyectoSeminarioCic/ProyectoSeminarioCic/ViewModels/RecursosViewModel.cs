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
    public class RecursosViewModel
    {
        SQLiteConnection dbConnection;
        public RecursosViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Recurso> GetList()
        {
            return dbConnection.Table<Recurso>().ToList();
        }
        public int Insert(Recurso aRecurso)
        {
            return dbConnection.Insert(aRecurso);
        }
        public int Delete(Recurso aRecurso)
        {
            return dbConnection.Delete(aRecurso);
        }
        public int Update(Recurso aRecurso)
        {
            return dbConnection.Update(aRecurso);
        }
        public Recurso Consult(int Id)
        {
            return dbConnection.Table<Recurso>().FirstOrDefault(x => x.Id_recurso == Id);
        }

    }
}
