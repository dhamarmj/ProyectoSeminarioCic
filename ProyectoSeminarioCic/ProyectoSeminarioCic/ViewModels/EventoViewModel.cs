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
    public class EventoViewModel
    {
        SQLiteConnection dbConnection;
        public EventoViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Evento> GetList()
        {
            return dbConnection.Table<Evento>().ToList();
        }
        public int Insert(Evento aEvento)
        {
            return dbConnection.Insert(aEvento);
        }
        public int Delete(Evento aEvento)
        {
            return dbConnection.Delete(aEvento);
        }
        public int Update(Evento aEvento)
        {
            return dbConnection.Update(aEvento);
        }
        public Evento Consult(int Id)
        {
            return dbConnection.Table<Evento>().FirstOrDefault(x => x.Id_evento == Id);
        }

    }
}
