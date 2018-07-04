﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Publicacion")]
    public class Publicacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id_publicacion { get; set; }
        public string Pie_imagen { get; set; }
        public int Kaip { get; set; }
        public Usuario Usuario { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
