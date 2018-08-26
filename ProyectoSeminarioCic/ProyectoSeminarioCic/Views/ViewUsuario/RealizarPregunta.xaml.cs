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
    public partial class RealizarPregunta : ContentPage
    {
        Models.Evento_Usuario _eveU;
        Services.ApiServices_Preguntas api = new Services.ApiServices_Preguntas();
        public RealizarPregunta(Models.Evento_Usuario R)
        {
            InitializeComponent();
           // Title = "Realizar Pregunta";
            _eveU = R;
            btnenviar.Clicked += Btnenviar_Clicked;
        }
        private async void Btnenviar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryPregunta.Text))
            {
                var pregunta = new Models.Pregunta()
                {
                    Texto = entryPregunta.Text,
                    Id_evento_participante = _eveU.Id
                };
                var resp = await api.RegistrarPregunta(pregunta);
                if (resp)
                {
                    await DisplayAlert("Aviso", "Su pregunta ha sido enviada correctamente", "Ok");
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Alerta", "Error de conexión. Intente nuevamente", "Ok");
            }
            else
                await DisplayAlert("Alerta", "Debes redactar uan pregunta!", "Ok");

        }
    }
}