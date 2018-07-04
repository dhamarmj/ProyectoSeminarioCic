using ProyectoSeminarioCic.Services;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ProyectoSeminarioCic.Models;
using System.Collections.ObjectModel;

namespace ProyectoSeminarioCic.ViewModels
{
    public class CharlaViewModel
    {
        SQLiteConnection dbConnection;
        public CharlaViewModel()
        {
            dbConnection = App.DAUtil.ReturnConnection();
        }

        public   List<Charla> GetList()
        {
            return dbConnection.Table<Charla>().ToList();
        }
        public   int Insert(Charla aCharla)
        {
            int val = -1;
            try
            {
                val = dbConnection.Insert(aCharla);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine("CHARLA");
                Console.WriteLine(ex.ToString());
            }
            return val;
        }
        public   int Delete(Charla aCharla)
        {
            return dbConnection.Delete(aCharla);
        }
        public   int Update(Charla aCharla)
        {
            return dbConnection.Update(aCharla);
        }
        public   Charla Consult(int Id)
        {
            return dbConnection.Table<Charla>().FirstOrDefault(x => x.Id_charla == Id);
        }

    }
}
