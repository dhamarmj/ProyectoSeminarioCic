using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Evento")]
    public class Evento
    {
        [PrimaryKey, AutoIncrement]
        public int Id_evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public string Duracion { get; set; }
        public string Comentario { get; set; }
        public string Titulo { get; set; }
        public Seminario Seminario { get; set; }
    }
}
