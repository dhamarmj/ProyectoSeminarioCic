using System;
using System.Collections.Generic;
using System.Text;
using ProyectoSeminarioCic.Models;
using ProyectoSeminarioCic.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace ProyectoSeminarioCic.ViewModels
{
   public class ListadoViewModelUsuario : UsuarioModel
    {
        private ObservableCollection<UsuarioModel> listadoUsuario;
        public ObservableCollection<UsuarioModel> ListadoUsuario
        {
            get
            {
                if (listadoUsuario == null)
                    LlenarUsuario();

                return listadoUsuario;
            }
            set { listadoUsuario = value; }
        }
        public void LlenarUsuario()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<UsuarioModel> modelo = new ObservableCollection<UsuarioModel>(contexto.Consultar());
                listadoUsuario = modelo;

            }

                

        }
    }
}
