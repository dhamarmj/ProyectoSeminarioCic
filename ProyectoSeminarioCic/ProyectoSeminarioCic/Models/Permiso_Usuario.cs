using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Permiso_Usuario")]
    public class Permiso_Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_permiso_usuario { get; set; }

      /*  [ForeignKey(typeof(Usuario))]
        public int Id_usuario { get; set; }
        [ForeignKey(typeof(Permiso))]
        public int Id_permiso { get; set; }/*/
        //[ManyToOne]
        public Usuario Usuario { get; set; }
        //[ManyToOne]
        public Permiso Permiso { get; set; }
        //[OneToMany]
        public List<Evento_Usuario> Evento_Usuarios { get; set; }
        //[OneToMany]
        public List<Charla_Usuario> Charla_Usuarios { get; set; }
        //[OneToMany]
        public List<Notificacion> Notificacions { get; set; }
        //[OneToMany]
        public List<Recurso> Recurso { get; set; }
        //[OneToOne]
        public Boleta Boleta { get; set; }
    }
}
    
    
    