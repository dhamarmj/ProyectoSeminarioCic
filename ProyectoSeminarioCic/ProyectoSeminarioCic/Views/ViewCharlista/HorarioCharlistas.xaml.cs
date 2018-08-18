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
        Services.ApiServices_Eventos api = new Services.ApiServices_Eventos();
        public HorarioCharlistas()
        {
            InitializeComponent();

            LoadCharla();
            
        }

        protected override void OnAppearing()
        {
            BtnLoading.IsRunning = true;
            if (_evento.FechaFin >= DateTime.Now)
                BtnPReguntas.IsVisible = true;
            else if (_evento.FechaFin.AddMinutes(10) >= DateTime.Now)
                BtnPReguntas.IsVisible = false;
            BtnLoading.IsRunning = false;
        }

            Models.Evento _evento;
        private async void LoadCharla()
        {
            BtnLoading.IsRunning = true;
            var resp = await api.GetEvento(Settings.idUsuario, Convert.ToInt32(Settings.idUsuario));
            _evento = resp;
            this.BindingContext = resp;
            BtnLoading.IsRunning = false;

        }

        async private void BtnPReguntas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetallePreguntas(_evento.Id));
        }
    }
}