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
        public void SetFechaFin()
        {
            FechaFin = Fecha.AddMinutes(Convert.ToDouble(Duracion));
        }
        public Evento(string desc)
        {
            Descripcion = desc;
        }

        public Evento()
        {
            FechaFin = Fecha = new DateTime();
            Descripcion = Ubicacion = Titulo = string.Empty;
            Id_seminario = 0;
            Duracion = 0;
        }
    }
}
