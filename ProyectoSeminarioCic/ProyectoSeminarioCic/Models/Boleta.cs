using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class Boleta
    {
        public int Id { get; set; }
        public string Numero_serie { get; set; }
        public int Id_seminario { get; set; }
        public int Id_usuario { get; set; }
       
    }
}
