﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Notificacion")]
    public class Notificacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id_notificacion { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public Usuario Administrador { get; set; }
    }
}
