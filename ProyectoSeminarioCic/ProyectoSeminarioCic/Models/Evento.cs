using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    // [Table("Evento")]
    public class Evento
    {

        //  [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public double Duracion { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaFin { get; set; }
        public int Id_seminario { get; set; }
        public int Id_Charlista { get; set; }

        //public string RangoHora
        //{
        //    get
        //    {
        //        return string.Format("Desde: {0} Hasta: {1}", Fecha.ToString("HH:mm tt"), FechaFin.ToString("HH:mm tt"));
        //    }
        //}

        public void SetFechaFin()
        {
           FechaFin= Fecha.AddMinutes(Convert.ToDouble(Duracion));
        }
        public Evento(string desc)
        {
            Descripcion = desc;
        }

        public Evento()
        {
            Fecha = new DateTime();
            FechaFin = new DateTime();
        }
    }
}
