using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("boleta")]
    public class Boleta
    {
        [PrimaryKey, AutoIncrement]
        public int Id_boleta { get; set; }
        public string Numero_serie { get; set; }
        public byte QR { get; set; }
       /* [ForeignKey(typeof(Seminario))]
        public int Id_seminario { get; set; }
        [ForeignKey(typeof(Permiso_Usuario))]*/
        public int Id_permiso_usuario { get; set; }
        //[ManyToOne]
        public Seminario Seminario { get; set; }

    }
}
