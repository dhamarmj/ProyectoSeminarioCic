using ProyectoSeminarioCic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        Usuario _user;
        public Profile()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            BtnLoading.IsRunning = true;
            Init();
            BtnLoading.IsRunning = false;
        }

        private async void Init()
        {
            BtnLoading.IsRunning = true;

            var resp = await api.GetUsuario(Convert.ToInt32(Settings.idUsuario));
            if (resp != null)
            {
                _user = resp;
                if (!string.IsNullOrEmpty(_user.FotoPath))
                    _user.FotoPath = "http://proyectosapi.azurewebsites.net" + resp.FotoPath.Remove(0, 1);
                else
                    _user.FotoPath = "baseline_account_circle_black_48.png";

                LblNombre.Text = resp.Nombre + " " + resp.Apellido;
                this.BindingContext = _user;
            }

            BtnLoading.IsRunning = false;
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditarPerfil(_user));
        }

        private  void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Settings.Rol = Settings.Password = Settings.idUsuario = Settings.idSeminario = Settings.idBoleta = Settings.Email = string.Empty;
            var nv = new NavigationPage(new Login());
            nv.BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
            App.Current.MainPage = nv;
        }
    }
}