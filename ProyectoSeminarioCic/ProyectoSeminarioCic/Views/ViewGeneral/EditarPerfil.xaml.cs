using Plugin.Media;
using ProyectoSeminarioCic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPerfil : ContentPage
    {
        Usuario user;
        bool flagCorreo = false, flagContra = false, flaguser = false;
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        public EditarPerfil(Usuario u)
        {
            InitializeComponent();
            user = u;
            this.BindingContext = user;
        }

        private async Task<bool> CheckUsername()
        {
            if (flaguser)
            {
                var exists = await api.GetUsuario(TxtUsername.Text, 1);
                if (exists != null && exists.Id != Convert.ToInt32(Settings.idUsuario))
                {
                    await DisplayAlert("Aviso", "Este Nombre de Usuario no esta disponible, Intente de nuevo", "Ok");
                    flaguser = false;
                    return false;
                }

            }
            return true;
        }
        private bool ValidateCorreo()
        {
            if (flagCorreo)
            {
                try
                {
                    MailAddress m = new MailAddress(TxtCorreo.Text);
                }
                catch (FormatException)
                {
                    DisplayAlert("Alerta", "Correo electrónico inválido", "Ok");
                    flagCorreo = false;
                    return false;
                }

            }
            return true;
        }
        private bool ValidateContra()
        {
            if (flagContra)
            {
                Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
                if (!rgx.IsMatch(TxtContrasenia.Text))
                {
                    DisplayAlert("Error", "La contraseña debe contener de 8-15 caracteres; al menos 1 Mayúscula, Minúscula, Digito y Caracter especial", "OK");
                    flagContra = false;
                    return false;
                }
            }
            return true;
        }


        async private void Btnaceptar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (ValidateContra() && ValidateCorreo())
            {
                var cku = await CheckUsername();
                if (cku)
                {
                    user.Nombre = TxtNombre.Text;
                    user.Apellido = TxtApellido.Text;
                    user.Correo = TxtCorreo.Text;
                    user.Username = TxtUsername.Text;
                    user.Contrasenia = TxtContrasenia.Text;
                    user.Fecha_Nacimiento = TxtFecha.Date;
                    if (user.FotoPath == "baseline_account_circle_black_48.png")
                        user.FotoPath = "";
                    var resp = await api.ActualizarUsuario(user);
                    if (resp)
                    {
                        BtnLoading.IsRunning = false;
                        await DisplayAlert("Aviso", "Su perfil ha sido actualizado correctamente", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                        await DisplayAlert("Aviso", "Error de conexión. Intente nuevamente", "Ok");
                }
            }
            BtnLoading.IsRunning = false;


        }

        private void TxtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            flaguser = true;
        }

        private async void BtnGal_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error de Subida", "La foto seleccionada no es valida", "Aceptar");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            //lblfotodireccion.Text = file.AlbumPath;
            mainImage.Source = ImageSource.FromStream(() => file.GetStream());

            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                user.FotoArray = memoryStream.ToArray();
            }
        }

        private void TxtCorreo_TextChanged(object sender, TextChangedEventArgs e)
        {
            flagCorreo = true;
        }

        private void TxtContrasenia_TextChanged(object sender, TextChangedEventArgs e)
        {
            flagContra = true;
        }
    }
}