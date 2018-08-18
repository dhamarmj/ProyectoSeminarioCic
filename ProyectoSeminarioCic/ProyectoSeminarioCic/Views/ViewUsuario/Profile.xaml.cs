using ProyectoSeminarioCic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewUsuario
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
            InitializeComponent();
            Init();
            btnpregunta.Clicked += Btnpregunta_Clicked;
            btneditar.Clicked += Btneditar_Clicked;
        }

        private void Btneditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditarPerfil());
        }

        private void Btnpregunta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RealizarPregunta());
        }

        private void Init()
        {
            Models.Usuario user = new Models.Usuario();
            user = Controladora.Instance.User;
            profilefoto.Source = user.imagen;
            lblnomuser.Text = user.Username;
            lblocupacion.Text = user.Ocupacion;
            lblRol.Text = user.Rol;
            lblNombreCompleto.Text = user.Nombre + " " + user.Apellido;
        }
    }
}