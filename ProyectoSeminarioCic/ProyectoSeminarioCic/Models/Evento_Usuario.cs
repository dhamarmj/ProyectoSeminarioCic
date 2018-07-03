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
      /*  [ForeignKey(typeof(Evento))]
        public int Id_evento { get; set; }
        [ForeignKey(typeof(Permiso_Usuario))]
        public int Id_permiso_usuario { get; set; }/*/

        // [ManyToOne]
        public Permiso_Usuario Permiso_Usuario { get; set; }
        // [ManyToOne]
        public Evento Evento { get; set; }
    }
}
