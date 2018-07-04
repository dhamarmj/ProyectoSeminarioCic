using ProyectoSeminarioCic.Services;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ProyectoSeminarioCic.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.ViewModels
{
    public class UsuarioViewModel
    {
        SQLiteConnection dbConnection;
        public UsuarioViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public List<Usuario> GetList()
        {
            return dbConnection.Table<Usuario>().ToList();
        }
        public int Insert(Usuario aUsuario)
        {
            int val = -1;
            try
            {
                val = dbConnection.Insert(aUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine(ex.ToString());
            }


            return val;
        }
        public int Delete(Usuario aUsuario)
        {
            return dbConnection.Delete(aUsuario);
        }
        public int Update(Usuario aUsuario)
        {
            return dbConnection.Update(aUsuario);
        }
        public Usuario Consult(int Id)
        {
            return dbConnection.Table<Usuario>().FirstOrDefault(x => x.Id_usuario == Id);
        }

    }
}
