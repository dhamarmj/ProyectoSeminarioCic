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
	public partial class EditarPerfil : ContentPage
	{
        Usuario user = new Usuario();
        public EditarPerfil ()
		{
            InitializeComponent();
            Init();
            btnaceptar.Clicked += Btnaceptar_Clicked;
        }

        private void Init()
        {
            user = Controladora.Instance.tomarUsuario();
            entrynomuser.Text = user.Username;
            entrycontrasegna.Text = user.Contrasenia;
            entryRol.Text = user.Rol;
            entryOcupacion.Text = user.Ocupacion;
        }

        private void Btnaceptar_Clicked(object sender, EventArgs e)
        {
            user.Username = entrynomuser.Text;
            user.Contrasenia = entrycontrasegna.Text;
            user.Rol = entryRol.Text;
            user.Ocupacion = entryOcupacion.Text;
            DisplayAlert("Aviso", "Su perfil ha sido editado correctamente", "Aceptar");
            Navigation.PushModalAsync(new Profile());
        }
    }
}