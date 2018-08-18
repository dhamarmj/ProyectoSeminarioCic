using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Pregunta
    {
       
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public string Texto { get; set; }
        public int Id_evento_participante { get; set; }
    }
}
