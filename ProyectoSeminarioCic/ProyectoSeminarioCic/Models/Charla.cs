using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    [Table("charla")]
    public class Charla
    {
        [PrimaryKey, AutoIncrement]
        public int Id_charla { get; set; }
    }
}
