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
       /* [ForeignKey(typeof(Charla_Usuario))]
        public int Id_charla_participante { get; set; }/*/
        //[ManyToOne]
        public Charla_Usuario Charla_Usuario { get; set; }
    }
}
