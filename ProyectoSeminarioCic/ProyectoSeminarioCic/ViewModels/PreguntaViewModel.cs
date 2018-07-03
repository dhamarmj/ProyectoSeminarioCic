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
    public class PreguntaViewModel
    {
        SQLiteConnection dbConnection;
        public PreguntaViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Pregunta> GetList()
        {
            return dbConnection.Table<Pregunta>().ToList();
        }
        public int Insert(Pregunta aPregunta)
        {
            return dbConnection.Insert(aPregunta);
        }
        public int Delete(Pregunta aPregunta)
        {
            return dbConnection.Delete(aPregunta);
        }
        public int Update(Pregunta aPregunta)
        {
            return dbConnection.Update(aPregunta);
        }
        public Pregunta Consult(int Id)
        {
            return dbConnection.Table<Pregunta>().FirstOrDefault(x => x.Id_pregunta == Id);
        }

    }
}
