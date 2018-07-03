using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("recurso")]
    public class Recurso
    {
        [PrimaryKey, AutoIncrement]
        public int Id_recurso { get; set; }
        public string Titulo { get; set; }
        public string Recursos { get; set; }
      /*  [ForeignKey(typeof(Permiso_Usuario))]
        public int Id_permiso_usuario { get; set; }/*/
        //[ManyToOne]
        public Permiso_Usuario Permiso_Usuario { get; set; }
    }
}
