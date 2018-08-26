using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Pregunta
    {
       
        public int Id { get; set; }
        public string Texto { get; set; }
        public int Id_evento_participante { get; set; }
        public Pregunta()
        {
            Id_evento_participante = 0;
            Texto = string.Empty;
        }
    }
}
