using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro1 : ContentPage
    {
        Models.Usuario usuario;
        Services.ApiServices api = new Services.ApiServices();
        Services.ApiServices_CurrentSem apiSem = new Services.ApiServices_CurrentSem();
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        Services.ApiServices_CurrentSem apiCurrent = new Services.ApiServices_CurrentSem();
        public Registro1(Models.Usuario u)
        {
            InitializeComponent();
            Init();
            btnsiguiente.Clicked += Btnsiguiente_Clicked;
            usuario = u;
            this.BindingContext = this;
        }

        public async void loadSem()
        {
            var R = await apiSem.GetMainSeminario(1);
            if (R != null)
                Settings.idSeminario = R.Id_Seminario.ToString();
        }

        private void Init()
        {
            pickergenero.Items.Add("Masculino");
            pickergenero.Items.Add("Femenino");

        }
        private async void checkCharlista()
        {

            var clave = await apiCurrent.GetMainSeminario(1);
            if (usuario.Contrasenia == clave.ClaveCharlistas)
            {
                usuario.Rol = "Charlista";
            }
            Settings.idSeminario = clave.Id_Seminario.ToString();
        }




        async private void Btnsiguiente_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                usuario.Nombre = Txtnom.Text.ToLower();
                usuario.Apellido = Txtapellido.Text.ToLower();
                usuario.Fecha_Nacimiento = btnfecha.Date;
                usuario.Genero = pickergenero.Items[pickergenero.SelectedIndex].ToString();
                usuario.Rol = "Participante";

                BtnLoading.IsRunning = true;

                checkCharlista();
                loadSem();

                var httpclient = await api.RegisterUser(usuario.Correo, usuario.Contrasenia, usuario.Contrasenia);
                var res = await api.LoginUser(usuario.Correo, usuario.Contrasenia);
                if (res)
                {
                    var usersaved = await apiUsuario.RegistrarUsuario(usuario);
                    if (usersaved)
                    {
                        LoadidUser();
                        Settings.Rol = usuario.Rol;
                        if (Settings.Rol == "Charlista" || Settings.Rol == "Participante")
                        {
                            Navigation.InsertPageBefore(new Home(), this);
                            await Navigation.PopAsync();
                        }
                        //else if (Settings.Rol == "Participante")
                        //{
                        //    var nv = new ViewUsuario.ScanHome();
                        //    Navigation.InsertPageBefore(nv, this);
                        //    await Navigation.PopAsync();
                        //}
                        else
                        {
                            Navigation.InsertPageBefore(new ViewAdmin.MainMenu(), this);
                            await Navigation.PopAsync();
                        }

                    }
                    else
                        await DisplayAlert("Alerta", "Error de conexión, intente de nuevo", "ok");

                }
                else
                    await DisplayAlert("Alerta", "Error de conexión, intente de nuevo", "Ok");
            }
            BtnLoading.IsRunning = false;
        }
        private bool Validate()
        {
            if (!string.IsNullOrEmpty(Txtnom.Text) && !string.IsNullOrEmpty(Txtapellido.Text))
            {
                if (btnfecha.Date.Year + 10 > DateTime.Now.Year)
                {
                    DisplayAlert("Alerta", "Fecha de nacimiento incorrecta", "Ok");
                    pickergenero.Focus();
                    return false;
                }
                if (pickergenero.SelectedIndex == -1)
                {
                    DisplayAlert("Alerta", "Escoge tu género", "Ok");
                    pickergenero.Focus();
                    return false;
                }
            }
            else
            {
                DisplayAlert("Alerta", "Completa todas las informaciones!", "Ok");
                return false;
            }
            return true;
        }
        private async void LoadidUser()
        {
            if (string.IsNullOrEmpty(Settings.idUsuario))
            {
                var Y = await apiUsuario.GetUsuario(usuario.Username, Settings.Password);
                if (Y != null)
                    Settings.idUsuario = Y.Id.ToString();
            }
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
                usuario.FotoArray = memoryStream.ToArray();
            }
        }

    }
}