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
    public class Charla_UsuarioViewModel
    {
        SQLiteConnection dbConnection;
        public Charla_UsuarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Charla_Usuario> GetList()
        {
            return dbConnection.Table<Charla_Usuario>().ToList();
        }
        public int Insert(Charla_Usuario aCharla_Usuario)
        {
            return dbConnection.Insert(aCharla_Usuario);
        }
        public int Delete(Charla_Usuario aCharla_Usuario)
        {
            return dbConnection.Delete(aCharla_Usuario);
        }
        public int Update(Charla_Usuario aCharla_Usuario)
        {
            return dbConnection.Update(aCharla_Usuario);
        }
        public Charla_Usuario Consult(int Id)
        {
            return dbConnection.Table<Charla_Usuario>().FirstOrDefault(x => x.Id_Charla_Participante == Id);
        }

    }
}
