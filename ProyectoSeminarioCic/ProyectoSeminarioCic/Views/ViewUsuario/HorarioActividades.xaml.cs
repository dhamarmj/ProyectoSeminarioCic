using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorarioActividades : ContentPage
    {
        Services.ApiServices_Eventos api = new Services.ApiServices_Eventos();
        public HorarioActividades()
        {
            InitializeComponent();

            //_eventos = new ObservableCollection<Models.Evento>
            //{
            //    new Models.Charla { Id_Charlista =1, Ubicacion= "Aula 1", Titulo = "Comida en el dia de hoy", Duracion = "90", Descripcion ="Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself." ,Fecha = new DateTime(2016,06,15), TSHora = new TimeSpan(5,0,0),  },
            //    new Models.Charla { Id_Charlista =2, Ubicacion= "Aula 2",Titulo = "Bebida en el dia de hoy", Duracion = "90", Descripcion ="Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself.", Fecha = new DateTime(2016,06,15),  TSHora = new TimeSpan(6,0,0)  },
            //    new Models.Evento { Titulo = "Llegada", Ubicacion= "Teatro", Duracion = "30", Fecha = new DateTime(2016,06,15,5,0,0),  Descripcion ="Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself.", TSHora = new TimeSpan(7,0,0) },
            //};
            LoadEventos();
            ListEventos.ItemsSource = _eventos;
        }

        public async void LoadEventos()
        {
            var list = await api.GetEventos();
            _eventos = new ObservableCollection<Models.Evento>(list);
            ListEventos.ItemsSource = _eventos;
            ListEventos.EndRefresh();
        }

        ObservableCollection<Models.Evento> _eventos;
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            
            var task = (sender as Switch).BindingContext as Models.Evento;
            if(e.Value)
            {
                if (task != null)
                {
                    DisplayAlert("Aviso", task.Titulo + " fue agregado a tus eventos!", "Ok");
                    //  await ApiManager.UpdateTasksFromListAsync(task);
                    //  TaskList.Remove(task);
                }
            }
            else
            {
                if (task != null)
                {
                    DisplayAlert("Aviso", "Haz eliminado " + task.Titulo + " de tus eventos", "Ok");
                    //  await ApiManager.UpdateTasksFromListAsync(task);
                    //  TaskList.Remove(task);
                }
            }
            
        }

        private void ListEventos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.Evento evento;
            evento = e.SelectedItem as Models.Evento;
            if (evento != null)
                Navigation.PushAsync(new DetalleActividades(evento));
        }

        private void ListEventos_Refreshing(object sender, EventArgs e)
        {
            LoadEventos();
        }
    }
}