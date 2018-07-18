using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Seminario")]
    public class Seminario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_seminario { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Anio { get; set; }
        public byte[] Imagen { get; set; }
        public string icon { get; set; }

        public Seminario()
        {
            Descripcion = "/n /n Descripción del seminario";
        }
    }

}
