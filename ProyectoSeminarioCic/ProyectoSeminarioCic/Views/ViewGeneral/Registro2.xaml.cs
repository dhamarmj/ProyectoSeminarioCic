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
       // Usuario usuario;
        public Registro2()
        {
            InitializeComponent();
            //  usuario = u;
        }

        async private void Btnconfirmar_Clicked(object sender, EventArgs e)
        {
            var validate = await Validate();
            if (validate)
            {
                var usuario = new Models.Usuario
                {
                    Correo = TxtEmail.Text,
                    Contrasenia = TxtPass.Text,
                    Username = TxtUsername.Text
                };

                await Navigation.PushAsync(new Registro1(usuario));
            }
          
            //var val = await ValidateData();
            //if (val)
            //{
            //    usuario.Correo = TxtEmail.Text;
            //    usuario.Contrasenia = TxtPass.Text;
            //    usuario.Username = TxtUsername.Text;
            //    usuario.Rol = "Participante";
            //    Services.ApiServices api = new Services.ApiServices();
            //    var httpclient = await api.RegisterUser(usuario.Correo, usuario.Contrasenia, usuario.Contrasenia);
            //    if (httpclient.IsSuccessStatusCode)
            //    {
            //        var res = await api.LoginUser(usuario.Correo, usuario.Contrasenia);
            //        if (res)
            //        {
            //            var usersaved = await api.RegisterUser(usuario);
            //            if (usersaved)
            //            {
            //                var us = await api.CheckUsername(usuario.Correo, usuario.Contrasenia);
            //                Settings.Rol = us.Rol;
            //                if (Settings.Rol == "Charlista" || Settings.Rol == "Participante")
            //                {
            //                    Navigation.InsertPageBefore(new ViewGeneral.Home(usuario.Rol), this);
            //                    await Navigation.PopAsync();
            //                }
            //                else
            //                {
            //                    Navigation.InsertPageBefore(new ViewAdmin.MainMenu(), this);
            //                    await Navigation.PopAsync();
            //                }
            //            }
            //            else
            //                await DisplayAlert("Alerta", "Error al crear el Usuario", "Cancelar");
            //        }
            //        else
            //            await DisplayAlert("Alerta", "Error al obtener la llave de conexión", "Cancelar");
            //    }
            //    else
            //    {
            //        //var text = await httpclient.Content.ReadAsStringAsync();
            //        await DisplayAlert("Alerta", "Error al registrar autenticación", "Cancelar");
            //    }

            //}
        }
        async private Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(TxtUsername.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un usuario", "Aceptar");
                TxtUsername.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Correo Válido", "Aceptar");
                TxtEmail.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtPass.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una Contraseña", "Aceptar");
                TxtPass.Focus();
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(TxtEmail.Text);
            }
            catch (FormatException)
            {
                await DisplayAlert("Alerta", "Correo electrónico inválido", "Ok");
                return false;
            }
            Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            if (!rgx.IsMatch(TxtPass.Text))
            {
                await DisplayAlert("Error", "La contraseña debe contener de 8-15 caracteres; al menos 1 Mayúscula, Minúscula, Digito y Caracter especial", "OK");
                return false;
            }
                

            return true;
        }
        
    }
}
