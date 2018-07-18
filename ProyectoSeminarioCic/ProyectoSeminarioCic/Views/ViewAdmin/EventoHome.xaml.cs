using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoHome : ContentPage
    {
        private ObservableCollection<Models.Evento> _eventos;
        public EventoHome()
        {
            InitializeComponent();

            var sem1 = new Models.Seminario { Titulo = "Seminario", Anio = new DateTime(2016, 06, 15), Descripcion = "ALGO" };

            _eventos = new ObservableCollection<Models.Evento>
            {
                new Models.Charla { Titulo = "Comida en el dia de hoy", Duracion = "90", Descripcion ="Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself." ,Fecha = new DateTime(2016,06,15), Seminario=sem1 , TSHora = new TimeSpan(5,0,0),  },
                new Models.Charla { Titulo = "Bebida en el dia de hoy", Duracion = "90", Descripcion ="Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself.", Fecha = new DateTime(2016,06,15), Seminario=sem1 , TSHora = new TimeSpan(6,0,0)  },
                new Models.Evento { Titulo = "Llegada", Duracion = "30", Fecha = new DateTime(2016,06,15,5,0,0), Seminario=sem1, Descripcion ="Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself.", TSHora = new TimeSpan(7,0,0) },
            };
            this.BindingContext = sem1;
            ListEvento.ItemsSource = _eventos;
        }


        async private void Editar_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var eve = item.CommandParameter as Models.Evento;
            await Navigation.PushAsync(new CU_Evento(eve));
        }

        async private void Eliminar_Clicked(object sender, EventArgs e)
        {
            //VALIDAR SI SE PUEDE BORRAR <SI NO TIENE NINGUNA PERSONA AGREGADA>
            var res = await DisplayAlert("Aviso", "Está a punto de eliminar un Evento, ¿Está seguro?", "Sí", "No");
            if (res)
            {
                var eve = (sender as MenuItem).CommandParameter as Models.Evento;
                _eventos.Remove(eve);
                await DisplayAlert("Éxito", "Registro eliminado", "Aceptar");
            }
        }

       async private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CU_Evento(new Models.Evento("Descripción del evento")));
        }

        private void CambiarSeminario_Clicked(object sender, EventArgs e)
        {

        }
    }
}