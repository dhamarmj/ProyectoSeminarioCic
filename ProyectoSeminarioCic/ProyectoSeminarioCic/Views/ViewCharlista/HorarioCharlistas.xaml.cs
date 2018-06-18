using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;

namespace ProyectoSeminarioCic.Views.ViewCharlista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorarioCharlistas : ContentPage
    {
        public HorarioCharlistas()
        {
            InitializeComponent();

            var horario1 = new CharlaModel
            {
                Titulo = "La gente",
                FechaHora = new DateTime(2019, 06, 15, 5, 30, 0),
                Duracion = 50,
                Descripcion = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                Ubicacion = "Teatro universitario, sala principal"
            };

            // ListContent.ItemsSource = horario;
            this.BindingContext = horario1;
        }

        async private void ButtonHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeCharlistas());
        }

        async private void ButtonNotifications_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeNotificaciones());
        }

        private void ButtonPost_Clicked(object sender, EventArgs e)
        {

        }

        async private void ButtonSchedule_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HorarioCharlistas());
        }

        private void ButtonConfiguration_Clicked(object sender, EventArgs e)
        {

        }
    }
}