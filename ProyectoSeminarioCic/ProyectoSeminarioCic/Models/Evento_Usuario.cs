using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
   // [Table("Evento_Usuario")]
    public class Evento_Usuario
    {
      //  [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Id_evento { get; set; }
        public int Id_usuario { get; set; }
    }
}
