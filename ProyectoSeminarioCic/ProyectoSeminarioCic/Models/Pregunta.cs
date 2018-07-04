using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Pregunta")]
    public class Pregunta
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pregunta { get; set; }
        public string Texto { get; set; }
    }
}
