using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;

namespace ProyectoSeminarioCic.Services
{
   public interface IConfiguration
    {
         string directorio { get; }
        ISQLitePlatform plataforma { get; }
    }
}
