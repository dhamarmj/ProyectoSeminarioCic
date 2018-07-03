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
    public class BoletaViewModel
    {
        SQLiteConnection dbConnection;
        public BoletaViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Boleta> GetList()
        {
            return dbConnection.Table<Boleta>().ToList();
        }
        public int Insert(Boleta aBoleta)
        {
            return dbConnection.Insert(aBoleta);
        }
        public int Delete(Boleta aBoleta)
        {
            return dbConnection.Delete(aBoleta);
        }
        public int Update(Boleta aBoleta)
        {
            return dbConnection.Update(aBoleta);
        }
        public Boleta Consult(int Id)
        {
            return dbConnection.Table<Boleta>().FirstOrDefault(x => x.Id_boleta == Id);
        }

    }
}
