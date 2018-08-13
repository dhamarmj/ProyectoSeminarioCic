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
        public TimeSpan TSHora { get; set; }
        public string Ubicacion { get; set; }
        public string Duracion { get; set; }
        public string Comentario { get; set; }
        public string Titulo { get; set; }
        public string RangoHora
        {
            get
            {
                if (TSHora != null && Duracion != string.Empty)
                {
                    var time = TimeSpan.FromMinutes(Convert.ToInt32(Duracion));
                    if (time.Equals(0))
                        return string.Format("Desde: {0}", TSHora.ToString(@"hh\:mm"));
                    else
                        return string.Format("Desde: {0} Hasta: {1}", TSHora.ToString(@"hh\:mm"), TSHora.Add(time).ToString(@"hh\:mm"));
                }
                else
                   return string.Format("Desde: {0}", TSHora);
            }
        }

        public Evento(string desc)
        {
            Descripcion = desc;


        }

        public Evento()
        {
        }
    }
}
