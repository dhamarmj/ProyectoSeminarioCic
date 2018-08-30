using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro2 : ContentPage
    {
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        //Usuario usuario;
        public Registro2()
        {
            InitializeComponent();
            //  usuario = u;
        }


        async private void Btnconfirmar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (Validate())
            {
                var v = await CheckUsername();
                if (v)
                {
                    var usuario = new Models.Usuario
                    {
                        Correo = TxtEmail.Text.ToLower(),
                        Contrasenia = TxtPass.Text,
                        Username = TxtUsername.Text.ToLower()
                    };
                    BtnLoading.IsRunning = false;
                    await Navigation.PushAsync(new Registro1(usuario));
                }
            }
            BtnLoading.IsRunning = false;
        }

        private async Task<bool> CheckUsername()
        {
            var exists = await api.GetUsuario(TxtUsername.Text, 1);
            if (exists != null)
            {
                await DisplayAlert("Aviso", "Este Nombre de Usuario no esta disponible, Intente de nuevo", "Ok");
                return false;
            }

            return true;
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(TxtUsername.Text))
            {
                DisplayAlert("Error", "Debe ingresar un nombre de usuario", "Aceptar");
                TxtUsername.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                DisplayAlert("Error", "Debe ingresar un Correo Válido", "Aceptar");
                TxtEmail.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtPass.Text))
            {
                DisplayAlert("Error", "Debe ingresar una Contraseña", "Aceptar");
                TxtPass.Focus();
                return false;
            }
            else if (TxtPass.Text != TxtPassC.Text)
            {
                DisplayAlert("Error", "Las contraseñas no coinciden", "Aceptar");
                TxtPass.Focus();
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(TxtEmail.Text);
            }
            catch (FormatException)
            {
                DisplayAlert("Alerta", "Correo electrónico inválido", "Ok");
                return false;
            }
            Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            if (!rgx.IsMatch(TxtPass.Text))
            {
                DisplayAlert("Error", "La contraseña debe contener de 8-15 caracteres; al menos 1 Mayúscula, Minúscula, Digito y Caracter especial", "OK");
                return false;
            }


            return true;
        }

    }
}
