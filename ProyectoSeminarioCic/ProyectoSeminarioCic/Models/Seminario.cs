using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Seminario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Anio { get; set; }
        public string ImagenPath { get; set; }
        public byte[] ImagenArray { get; set; }
        public string Icon { get; set; }


        public virtual ICollection<Boleta> Boleta { get; set; }
        public virtual ICollection<Charla> Charla { get; set; }
        public virtual ICollection<Evento> Evento { get; set; }

    }

}
