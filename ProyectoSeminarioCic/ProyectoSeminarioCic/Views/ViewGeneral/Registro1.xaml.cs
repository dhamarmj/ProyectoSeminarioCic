using Plugin.Media;
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
    public partial class Registro1 : ContentPage
    {
        Models.Usuario usuario;
        Services.ApiServices api = new Services.ApiServices();
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        public Registro1(Models.Usuario u)
        {
            InitializeComponent();
            Init();
            btnsiguiente.Clicked += Btnsiguiente_Clicked;
            usuario = u;
            this.BindingContext = this;
        }
        private void Init()
        {
            pickergenero.Items.Add("Masculino");
            pickergenero.Items.Add("Femenino");

        }

        async private void Btnsiguiente_Clicked(object sender, EventArgs e)
        {
            
            if (Validate())
            {
                
                usuario.Nombre = Txtnom.Text;
                usuario.Apellido = Txtapellido.Text;
                usuario.Fecha_Nacimiento = btnfecha.Date;
                usuario.Genero = pickergenero.Items[pickergenero.SelectedIndex].ToString();
                usuario.Rol = "Participante";

                BtnLoading.IsRunning = true;

                var httpclient = await api.RegisterUser(usuario.Correo, usuario.Contrasenia, usuario.Contrasenia);
                if (httpclient)
                {
                    var res = await api.LoginUser(usuario.Correo, usuario.Contrasenia);
                    if (res)
                    {
                        var usersaved = await apiUsuario.RegistrarUsuario(usuario);
                        if (usersaved)
                        {
                            Settings.Rol = usuario.Rol;
                            Settings.idUsuario = usuario.Id.ToString();
                            if (Settings.Rol == "Charlista" )
                            {
                                Navigation.InsertPageBefore(new ViewGeneral.Home(), this);
                                await Navigation.PopAsync();
                            }
                            else if (Settings.Rol == "Participante")
                            {
                                Navigation.InsertPageBefore(new ViewUsuario.ScanHome(), this);
                                await Navigation.PopAsync();

                            }
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
            // user.imagen = ImageSource.FromStream(() => file.GetStream());
        }

        private async Task BtnCam_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error de Camara", "Camara No disponible", "Aceptar");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = "prueba.jpg"
            });

            if (file == null)
                return;

            mainImage.Source = ImageSource.FromStream(() => file.GetStream());

        }
    }
}