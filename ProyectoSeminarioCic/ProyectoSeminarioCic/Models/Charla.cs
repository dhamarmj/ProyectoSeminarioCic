using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{

    public class Charla : Evento
    {
        //  [Table("Charla")]

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

