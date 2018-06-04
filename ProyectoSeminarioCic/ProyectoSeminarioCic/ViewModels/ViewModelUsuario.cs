using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoSeminarioCic.Models;
using ProyectoSeminarioCic.Services;

namespace ProyectoSeminarioCic.ViewModels
{
    public class ViewModelUsuario : UsuarioModel
    {
        public ICommand Guardar { get; private set; }
        public ICommand Modificar { get; private set; }
        public ICommand Eliminar { get; private set; }
        public ICommand Limpiar { get; private set; }

        public ViewModelUsuario()
        {
            Guardar = new Command(() =>
            {
                UsuarioModel modelo = new UsuarioModel()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Username = Username,
                    Correo = Correo,
                    Contrasenia = Contrasenia,
                    FechaNac = FechaNac,
                    Genero = Genero,
                    Ocupacion = Ocupacion
                };

                using (var contexto = new DataContext())
                {
                    contexto.Insertar(modelo);
                }
            });
            Modificar = new Command(() =>
            {
                UsuarioModel modelo = new UsuarioModel()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Username = Username,
                    Correo = Correo,
                    Contrasenia = Contrasenia,
                    FechaNac = FechaNac,
                    Genero = Genero,
                    Ocupacion = Ocupacion,
                    IdUsuario=IdUsuario
                };

                using (var contexto = new DataContext())
                {
                    contexto.Modificar(modelo);
                }
            });
            Eliminar = new Command(() =>
            {
                UsuarioModel modelo = new UsuarioModel()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Username = Username,
                    Correo = Correo,
                    Contrasenia = Contrasenia,
                    FechaNac = FechaNac,
                    Genero = Genero,
                    Ocupacion = Ocupacion,
                    IdUsuario = IdUsuario
                };

                using (var contexto = new DataContext())
                {
                    contexto.Eliminar(modelo);
                }
            });
            Limpiar = new Command(() =>
            {

                Nombre = string.Empty;
                Apellido = string.Empty;
                Username = string.Empty;
                Correo = string.Empty;
                Contrasenia = string.Empty;
                FechaNac = DateTime.Now;
                Genero = ' ';
                Ocupacion = string.Empty;
            });
        }
    }
}
