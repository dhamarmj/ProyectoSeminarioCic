using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
        public int Value6 { get; set; }
        public int Id_Evento_Participante { get; set; }

        public Evaluacion()
        {
            Id_Evento_Participante = Value1 = Value2 = Value3 = Value4 = Value5 = Value6 = 0;

        }
    }
}
