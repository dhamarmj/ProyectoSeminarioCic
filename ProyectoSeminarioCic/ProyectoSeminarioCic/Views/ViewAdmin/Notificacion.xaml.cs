using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notificacion : ContentPage
    {
        Services.ApiServicesNotificaciones api = new Services.ApiServicesNotificaciones();
        public Notificacion()
        {
            InitializeComponent();
            destinatarios = new List<string>
            {
                "Charlistas",
                "Participantes"
            };
            pickerbtn.ItemsSource = destinatarios;
        }

        private List<string> destinatarios;

        private void pickerbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex > -1)
            {
                picker.SelectedItem.ToString();
            }
        }

        private async Task btnIniciar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            var _notif = new Models.Notificacion
            {
                Titulo = TxtTitulo.Text,
                Subtitulo = TxtSubtitulo.Text,
                Descripcion = TxtDescripcion.Text,
                Link = TxtLinks.Text
            };
            if (_notif.Titulo != string.Empty && _notif.Descripcion != "Descripción" && pickerbtn.SelectedIndex > -1)
            {
                var resp = await api.RegistrarNotificacion(_notif);
                if (resp)
                {
                    await DisplayAlert("Aviso", "Notificación enviada exitosamente", "Ok");
                    LimpiarPantalla();
                }
                else
                    await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
            }
            else
                await DisplayAlert("Error", "Una notificación debe tener un título, una descripción y un destinatario", "Ok");
            BtnLoading.IsRunning = false;
        }

        private void LimpiarPantalla()
        {
            TxtSubtitulo.Text = TxtTitulo.Text = string.Empty;
            pickerbtn.SelectedIndex = -1;
            TxtDescripcion.Text = "Descripción";
            TxtLinks.Text = "Agregar Links";
        }
    }
}