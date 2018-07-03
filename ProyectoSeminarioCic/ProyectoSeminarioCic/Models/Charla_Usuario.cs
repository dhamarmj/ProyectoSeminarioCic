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
       /* [ForeignKey(typeof(Charla))]
        public int Id_charla { get; set; }
        [ForeignKey(typeof(Permiso_Usuario))]*/
        public int Id_permiso_usuario { get; set; }
        //[ManyToOne]
        public Permiso_Usuario Permiso_Usuario { get; set; }
        //[OneToMany]
        public List<Pregunta> Preguntas { get; set; }
       
    }
}
