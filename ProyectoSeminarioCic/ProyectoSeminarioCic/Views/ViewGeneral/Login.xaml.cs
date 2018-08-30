using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    public partial class Login : ContentPage
    {
        Services.ApiServices api = new Services.ApiServices();
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        Services.ApiServices_CurrentSem apiSem = new Services.ApiServices_CurrentSem();
        Services.ApiServices_Boletas apiBoleta = new Services.ApiServices_Boletas();

        public Login()
        {
            InitializeComponent();
        }

        async private void Btnreg_Clicked1(object sender, EventArgs e)
        {
            var nv = new NavigationPage(new ViewGeneral.Registro2())
            {
                BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor)
            };
            await Navigation.PushModalAsync(nv);
        }
        private async void loadSem()
        {
            var R = await apiSem.GetMainSeminario(1);
            if (R != null)
                Settings.idSeminario = R.Id_Seminario.ToString();
        }

        async private void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (Validate())
            {
                var resp = await api.RegisterUser(Txtnombre.Text, TxtPass.Text, TxtPass.Text);
                gettoken();
            }
            BtnLoading.IsRunning = false;
        }



        private async void gettoken()
        {
            var resp = await api.LoginUser(Txtnombre.Text, TxtPass.Text);
            if (resp)
            {
                var checkUser = await apiUsuario.GetUsuario(Txtnombre.Text, TxtPass.Text);
                if (checkUser != null)
                {
                    loadSem();
                    Settings.Rol = checkUser.Rol;
                    Settings.idUsuario = checkUser.Id.ToString();

                   // loadBoleta();
                    if (Settings.Rol == "Charlista" || Settings.Rol == "Participante") //&& !string.IsNullOrEmpty(Settings.idBoleta)))
                    {
                        Navigation.InsertPageBefore(new ViewGeneral.Home(), this);
                        await Navigation.PopAsync();
                    }
                    //else if ((Settings.Rol == "Participante" && string.IsNullOrEmpty(Settings.idBoleta)))
                    //{
                    //    var nv = new NavigationPage(new Views.ViewUsuario.ScanHome());
                    //    nv.BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
                    //    await Navigation.PushModalAsync(nv);
                    //}
                    else
                    {
                        Navigation.InsertPageBefore(new ViewAdmin.MainMenu(), this);
                        await Navigation.PopAsync();
                    }
                }
                else
                    await DisplayAlert("Aviso", "Usuario o contraseña inválidos, Intente de nuevo.", "Ok");
            }
            else
                await DisplayAlert("Aviso", "Usuario o contraseña inválidos, Intente de nuevo.", "Ok");
        }

        private async void loadBoleta()
        {
            var R = await apiBoleta.GetBoleta(Convert.ToInt32(Settings.idUsuario), Convert.ToInt32(Settings.idSeminario));
            if (R != null)
                Settings.idBoleta = R.Numero_serie;
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(Txtnombre.Text))
            {
                DisplayAlert("Error", "Debe ingresar un usuario", "Aceptar");
                Txtnombre.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtPass.Text))
            {
                DisplayAlert("Error", "Debe ingresar una Contraseña", "Aceptar");
                TxtPass.Focus();
                return false;
            }

            return true;
        }
    }
}