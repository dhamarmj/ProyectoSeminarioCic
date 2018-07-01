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
    public class ComentarioViewModel
    {
        SQLiteConnection dbConnection;
        public ComentarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Comentario> GetList()
        {
            return dbConnection.Table<Comentario>().ToList();
        }
        public int Insert(Comentario aComentario)
        {
            return dbConnection.Insert(aComentario);
        }
        public int Delete(Comentario aComentario)
        {
            return dbConnection.Delete(aComentario);
        }
        public int Update(Comentario aComentario)
        {
            return dbConnection.Update(aComentario);
        }
        public Comentario Consult(int Id)
        {
            return dbConnection.Table<Comentario>().FirstOrDefault(x => x.Id_comentario == Id);
        }

    }
}
