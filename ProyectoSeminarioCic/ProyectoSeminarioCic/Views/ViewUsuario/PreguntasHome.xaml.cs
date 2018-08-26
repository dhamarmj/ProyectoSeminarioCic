using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntasHome : ContentPage
    {
        Models.Evento _evento;
        Services.ApiServices_EventoUsuario api = new Services.ApiServices_EventoUsuario();
        Services.ApiServices_Evaluacion apiEval = new Services.ApiServices_Evaluacion();
        Models.Evento_Usuario _eveu;
        public PreguntasHome(Models.Evento evento)
        {
            InitializeComponent();
            _evento = evento;
            Title = _evento.Titulo;
            getUserEve();
            LblInsP.Text = "Podrás enviar preguntas a esta charla desde las " + evento.FechaFin.ToString("hh:mm tt") + " hasta " + evento.FechaFin.AddMinutes(10).ToString("hh:mm tt") + " el dia de la charla: " + evento.Fecha.ToLongDateString();
            LblInsE.Text = "Podrás evaluar esta charla cuando concluya a las " + evento.FechaFin.ToString("hh:mm tt") + " el dia de la charla: " + evento.Fecha.ToLongDateString();

        }
        protected override void OnAppearing()
        {
            checktime();
        }
        private void checktime()
        {
            var time = DateTime.Now;
            if (time >= _evento.FechaFin && time <= _evento.FechaFin.AddMinutes(10))
            {
                BtnPregunta.IsEnabled = true;
            }
            else
                BtnPregunta.IsEnabled = false;

            if (time >= _evento.FechaFin)
            {
                BtnEval.IsEnabled = true;
            }

        }

        private async void getUserEve()
        {
            if (_eveu == null)
            {
                var R = await api.GetEvento_Usuario(Convert.ToInt32(Settings.idUsuario), _evento.Id);
                if (R != null)
                    _eveu = R;
            }
        }

        private async void Preguntar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RealizarPregunta(_eveu));
        }

        private async void Evaluar_Clicked(object sender, EventArgs e)
        {
            var R = await apiEval.GetEvaluacion(_eveu.Id, "");
            if (R == null)
                await Navigation.PushAsync(new Encuesta(_eveu, _evento.Titulo));
            else
                await DisplayAlert("Alerta", "Ya evaluaste esta Charla!", "Ok");
        }
    }
}