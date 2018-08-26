using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    // [Table("Evento")]
    public class Evento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public double Duracion { get; set; }
        public DateTime FechaFin { get; set; }
        public string Titulo { get; set; }
        public int Id_seminario { get; set; }
        
        public Evento()
        {
            // Fecha.ToString("hh");
            Fecha = new DateTime();
            Duracion = 0;
            FechaFin = Fecha.AddMinutes(Duracion);
        }

        public string NewProperty => string.Format("{0} - {1} ", Fecha, FechaFin);
    }
}
