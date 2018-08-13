using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
  //  [Table("Charla")]
    public class Charla : Evento
    {

      //  [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

      //  [ForeignKey(typeof(Usuario))]
        public int Id_Charlista { get; set; }

        //public string returnCharlista
        //{
        //    get
        //    {
                
        //    }
        //}
    }
}
