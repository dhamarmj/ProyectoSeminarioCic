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
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        Usuario user = new Usuario();
        public EditarPerfil ()
		{
            InitializeComponent();
            Init();
            btnaceptar.Clicked += Btnaceptar_Clicked;
        }

        private async void Init()
        {
            var resp = await api.GetUsuario(Convert.ToInt32(Settings.idUsuario));
            //user = Controladora.Instance.tomarUsuario();
            entrynomuser.Text = resp.Username;
            entrycontrasegna.Text = resp.Contrasenia;
            entryRol.Text = resp.Rol;
            entryOcupacion.Text = resp.Ocupacion;
            _usuario = resp;
        }

        Usuario _usuario; 

        private async void Btnaceptar_Clicked(object sender, EventArgs e)
        {
            user.Username = entrynomuser.Text;
            user.Contrasenia = entrycontrasegna.Text;
            user.Rol = entryRol.Text;
            user.Ocupacion = entryOcupacion.Text;
            var V = await api.ActualizarUsuario(_usuario);
            await DisplayAlert("Aviso", "Su perfil ha sido editado correctamente", "Aceptar");
            await Navigation.PushModalAsync(new Profile());
        }
    }
}