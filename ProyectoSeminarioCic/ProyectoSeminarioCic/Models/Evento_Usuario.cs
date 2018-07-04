using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Evento_Usuario")]
    public class Evento_Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_evento_usuario { get; set; }
        public Usuario Participante { get; set; }
        public Evento Evento { get; set; }
    }
}
