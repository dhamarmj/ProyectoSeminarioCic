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
    public partial class HomePublicar : ContentPage
    {
        byte[] FotoArray;
        Services.ApiServices_Publicacion api = new Services.ApiServices_Publicacion();
        public HomePublicar()
        {
            InitializeComponent();
            Title = "Editar Publicación";
        }

        protected override void OnAppearing()
        {
           //if (FotoArray == null)
           //     OpenGalery();

        }

        private async void OpenGalery()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error de Subida", "La foto seleccionada no es valida", "Aceptar");
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file != null)
                {
                    mainImage.Source = ImageSource.FromStream(() => file.GetStream());

                    using (var memoryStream = new MemoryStream())
                    {
                        file.GetStream().CopyTo(memoryStream);
                        file.Dispose();
                        FotoArray = memoryStream.ToArray();
                    }
                }
               
            }

            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (FotoArray != null)
            {
                var publicacion = new Models.Publicacion()
                {
                    ImagenArray = FotoArray,
                    Id_usuario = Convert.ToInt32(Settings.idUsuario),
                    Pie_imagen = TxtPie.Text,
                };
                var R = await api.RegistrarPublicacion(publicacion);
                if (R)
                {
                    TxtPie.Text = string.Empty;
                    FotoArray = null;
                    mainImage.Source = "photo.png";
                    await DisplayAlert("Aviso", "Publicación Enviada!", "Ok");
                }
                else
                    await DisplayAlert("Alerta", "Error de conexión, intente de nuevo", "Ok");
            }
            else
                await DisplayAlert("Error", "Debes Seleccionar una Imagen de tu galería!", "Ok");

            BtnLoading.IsRunning = false;
        }

        private void Galery_Clicked(object sender, EventArgs e)
        {
            OpenGalery();
        }
    }
}