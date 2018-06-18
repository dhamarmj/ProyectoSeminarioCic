using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using System.ComponentModel;


namespace ProyectoSeminarioCic.Models
{
   public class UsuarioModel : INotifyPropertyChanged
    {
            private int idUsuario;
            private string nombre;
            private string apellido;
            private string username;
            private string correo;
            private string contrasenia;
            private DateTime fechaNac;
            private char genero;
            private string ocupacion;

        [PrimaryKey,AutoIncrement]
        public int IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (idUsuario != value)
                {
                    idUsuario = value;
                    OnPropertyChanged ("idUsuario");
                }
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged("nombre");
                }
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (apellido != value)
                {
                    apellido = value;
                    OnPropertyChanged("apellido");
                }
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("username");
                }
            }
        }
        public string Correo
        {
            get { return correo; }
            set
            {
                if (correo != value)
                {
                    correo = value;
                    OnPropertyChanged("correo");
                }
            }
        }
        public string Contrasenia
        {
            get { return contrasenia; }
            set
            {
                if (contrasenia != value)
                {
                    contrasenia = value;
                    OnPropertyChanged("contrasenia");
                }
            }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set
            {
                if (fechaNac != value)
                {
                    fechaNac = value;
                    OnPropertyChanged("fechaNac");
                }
            }
        }
        public char Genero
        {
            get { return genero; }
            set
            {
                if (genero != value)
                {
                    genero = value;
                    OnPropertyChanged("genero");
                }
            }
        }
        public string Ocupacion
        {
            get { return ocupacion; }
            set
            {
                if (ocupacion != value)
                {
                    ocupacion = value;
                    OnPropertyChanged("ocupacion");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
