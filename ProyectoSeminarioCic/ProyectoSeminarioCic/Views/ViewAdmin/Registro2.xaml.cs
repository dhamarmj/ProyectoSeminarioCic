using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro2 : ContentPage
	{
        Usuario usuario;
        ViewModels.UsuarioViewModel Modelo = new ViewModels.UsuarioViewModel();
		public Registro2 (Models.Usuario u)
		{
			InitializeComponent ();
            usuario = u;
            Modelo = new ViewModels.UsuarioViewModel();
            btnconfirmar.Clicked += Btnconfirmar_Clicked;
		}

        private void Btnconfirmar_Clicked(object sender, EventArgs e)
        {
            usuario.Nombre = "Dhamar";
            usuario.Apellido= "Martinez";
            usuario.Fecha_Nacimiento = new DateTime(1996,09,20);
            usuario.Username = "dhamarmj";
            usuario.Contrasenia = "tarea";
            usuario.Correo = "dhamarmj@hotmail.com";
            usuario.Rol = Rol.Charlista.ToString();

            Modelo.Insert(usuario);

            Charla c = new Charla();

            ViewModels.CharlaViewModel cvm = new ViewModels.CharlaViewModel();
            cvm.Insert(c);

         //  await Navigation.PushAsync(new ViewGeneral.Login());
        }
    }
}