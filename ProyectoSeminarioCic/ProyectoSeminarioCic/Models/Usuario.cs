﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
   public enum Rol
    {
       Charlista,
       Participante, 
       Administrador, 
       Personal
    };

  //  [Table("Usuario")]
    public class Usuario
    {
       // [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string FotoPath { get; set; }
        public string Genero { get; set; }
        public byte[] FotoArray { get; set; }
        public string Ocupacion { get; set; }
        public string Rol { get; set; }
        public int Id_evento { get; set; }

        public Usuario()
        {
            Nombre = Apellido = Username = Correo = Contrasenia = Genero = Ocupacion = Rol = string.Empty;
            Id_evento = 0;
            Fecha_Nacimiento = new DateTime();
        }

    }
}
