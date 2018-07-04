using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Boleta")]
    public class Boleta
    {
        [PrimaryKey, AutoIncrement]
        public int Id_boleta { get; set; }
        public string Numero_serie { get; set; }
        public byte QR { get; set; }
        public Seminario Seminario { get; set; }
        public Usuario Participante { get; set; }
    }
}
