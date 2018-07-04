using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Comentario")]
    public class Comentario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_comentario { get; set; }
        public string Texto { get; set; }
    }
}
