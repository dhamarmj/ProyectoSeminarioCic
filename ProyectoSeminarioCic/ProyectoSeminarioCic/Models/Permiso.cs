using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("Permiso")]
    public class Permiso
    {
        [PrimaryKey, AutoIncrement]
        public int Id_permiso { get; set; }
        public string Descripcion { get; set; }
    }
}
