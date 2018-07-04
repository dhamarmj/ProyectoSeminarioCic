using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Charla_Usuario")]
    public class Charla_Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Charla_Participante { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public Charla Charla { get; set; }
        public List<Usuario> Participantes { get; set; }
    }
}
