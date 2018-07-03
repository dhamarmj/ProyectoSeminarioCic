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
    public class SeminarioViewModel
    {
        SQLiteConnection dbConnection;
        public SeminarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Seminario> GetList()
        {
            return dbConnection.Table<Seminario>().ToList();
        }
        public int Insert(Seminario aSeminario)
        {
            return dbConnection.Insert(aSeminario);
        }
        public int Delete(Seminario aSeminario)
        {
            return dbConnection.Delete(aSeminario);
        }
        public int Update(Seminario aSeminario)
        {
            return dbConnection.Update(aSeminario);
        }
        public Seminario Consult(int Id)
        {
            return dbConnection.Table<Seminario>().FirstOrDefault(x => x.Id_seminario == Id);
        }

    }
}
