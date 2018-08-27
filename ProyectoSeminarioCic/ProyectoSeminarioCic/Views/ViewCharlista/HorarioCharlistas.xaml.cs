using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewCharlista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorarioCharlistas : ContentPage
    {
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        Services.ApiServices_Eventos apiEventos = new Services.ApiServices_Eventos();
        public HorarioCharlistas()
        {
            InitializeComponent();
            HeaderBar.Color = Color.FromHex(Proyecto.CurrrentSeminar.PrimaryColor);
           

        }

        protected override void OnAppearing()
        {
            BtnLoading.IsRunning = true;
            LoadCharla();
            if (_evento != null)
            {
                if (_evento.FechaFin >= DateTime.Now)
                    BtnPReguntas.IsVisible = true;
                else if (_evento.FechaFin.AddMinutes(10) >= DateTime.Now)
                    BtnPReguntas.IsVisible = false;
            }
            BtnLoading.IsRunning = false;
        }

        Models.Evento _evento;
        private async void LoadCharla()
        {
            BtnLoading.IsRunning = true;
            var resp = await api.GetUsuario(Convert.ToInt32(Settings.idUsuario));
            if (resp != null)
            {
                int eventoid = resp.Id_evento;
                if (eventoid > 0)
                {
                    var R = await apiEventos.GetEvento(Convert.ToInt32(eventoid));
                    if (R != null)
                    {
                        _evento = R;
                        this.BindingContext = R;
                    }
                }
                else
                    await DisplayAlert("Aviso","No tienes charlas registradas en este momento", "Ok");
            }
            BtnLoading.IsRunning = false;
        }

        async private void BtnPReguntas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetallePreguntas(_evento.Id));
        }
    }
}