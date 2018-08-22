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
        public Login()
        {
            InitializeComponent();
        }

        async private void Btnreg_Clicked1(object sender, EventArgs e)
        {
            var nv = new NavigationPage(new ViewGeneral.Registro2())
            {
                BarBackgroundColor = Color.LightSlateGray
            };
            await Navigation.PushModalAsync(nv);
        }

        async private void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (Validate())
            {
                if (Settings.Email == string.Empty)
                {
                    var resp = await api.RegisterUser(Txtnombre.Text + "@hotmailedu.com.do", TxtPass.Text, TxtPass.Text);
                    if (resp)
                    {
                        gettoken();
                    }
                    else
                        await DisplayAlert("Aviso", "Error de conexión", "Ok");
                }
                else
                {
                    gettoken();

                }
            }
            BtnLoading.IsRunning = false;
        }



        private async void gettoken()
        {
            var r = await api.LoginUser(Settings.Email, Settings.Password);
            if (r)
            {
                var checkUser = await apiUsuario.GetUsuario(Txtnombre.Text, Settings.Password);
                if (checkUser != null)
                {
                    Settings.Rol = checkUser.Rol;
                    Settings.idUsuario = checkUser.Id.ToString();
                    if (Settings.Rol == "Charlista" || ( Settings.Rol == "Participante"  && !string.IsNullOrEmpty(Settings.idBoleta)))
                    {
                        Navigation.InsertPageBefore(new ViewGeneral.Home(), this);
                        await Navigation.PopAsync();
                    }
                    else if ((Settings.Rol == "Participante" && string.IsNullOrEmpty(Settings.idBoleta)))
                    {
                       await Navigation.PushModalAsync(new Views.ViewUsuario.ScanHome());
                    }
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
                await DisplayAlert("Aviso", "Error de conexión", "Ok");
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