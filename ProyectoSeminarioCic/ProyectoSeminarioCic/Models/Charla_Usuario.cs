using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
   // [Table("Charla_Usuario")]
    public class Charla_Usuario
    {
       // [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Id_charla { get; set; }
        public int Id_usuario { get; set; }
        public List<Pregunta> Preguntas { get; set; }

        public Charla_Usuario()
        {
            Preguntas = new List<Pregunta>();
        }

    }
}
