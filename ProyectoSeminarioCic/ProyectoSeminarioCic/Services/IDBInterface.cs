
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Services
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
