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
    public class NotificacionViewModel
    {
        SQLiteConnection dbConnection;
        public NotificacionViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }
        public List<Notificacion> GetList()
        {
            return dbConnection.Table<Notificacion>().ToList();
        }
        public int Insert(Notificacion aNotificacion)
        {
            return dbConnection.Insert(aNotificacion);
        }
        public int Delete(Notificacion aNotificacion)
        {
            return dbConnection.Delete(aNotificacion);
        }
        public int Update(Notificacion aNotificacion)
        {
            return dbConnection.Update(aNotificacion);
        }
        public Notificacion Consult(int Id)
        {
            return dbConnection.Table<Notificacion>().FirstOrDefault(x => x.Id_notificacion == Id);
        }

    }
}
