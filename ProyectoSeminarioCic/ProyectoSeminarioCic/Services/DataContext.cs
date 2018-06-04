using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using ProyectoSeminarioCic.Models;
using System.Linq;

namespace ProyectoSeminarioCic.Services
{
    public class DataContext : IDisposable
    {
        private SQLiteConnection cnn;

        public DataContext()
        {
            var configuration= DependencyService.Get<IConfiguration>();
            cnn = new SQLiteConnection(configuration.plataforma, Path.Combine(configuration.directorio,"proyectoSeminario.db3"));
            cnn.CreateTable<UsuarioModel>();
        }
        public void Dispose()
        {
            cnn.Dispose();
        }

        public void Insertar(UsuarioModel usuario)
        {
            cnn.Insert(usuario);

        }
        public void Modificar (UsuarioModel usuario)
        {
            cnn.Update(usuario);
        }

        public void Eliminar(UsuarioModel usuario)
        {
            cnn.Update(usuario);
        }
        public UsuarioModel Consultar(int id)
        {
            return cnn.Table<UsuarioModel>().FirstOrDefault(u => u.IdUsuario == id);
        }
        public List<UsuarioModel> Consultar()
        {
            return cnn.Table<UsuarioModel>().ToList();
        }
    }

}
