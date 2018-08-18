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
        Services.ApiServices_EventoUsuario apiEventosU = new Services.ApiServices_EventoUsuario();
        public HorarioActividades()
        {
            InitializeComponent();
            LoadEventos();
            ListEventos.ItemsSource = _eventos;
        }

        public async void LoadEventos()
        {
            var list = await api.GetEventos(Convert.ToInt32(Settings.idSeminario));
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
                    var eu = new Models.Evento_Usuario()
                    {
                        Id_evento = task.Id,
                        Id_usuario = Convert.ToInt32(Settings.idUsuario)
                    };
                    GuardarEu(eu, task.Titulo);
                }
            }
            else
            {
                if (task != null)
                {
                    EliminarEu(task.Id, task.Titulo);
                }
            }
            
        }
        private async void EliminarEu(int idEve, string Titulo)
        {
            var objectEve = await apiEventosU.GetEvento_Usuario(Convert.ToInt32(Settings.idUsuario),idEve);
            if(objectEve != null)
            {
                var resp = await apiEventosU.EliminarEvento_Usuario(objectEve.Id);
                if (resp)
                    await DisplayAlert("Aviso", "Haz eliminado " + Titulo + " de tus eventos", "Ok");
                else
                    await DisplayAlert("Aviso", "Error de conexión, intenta de nuevo", "Ok");
            }
          
        }
        private async void GuardarEu(Models.Evento_Usuario EveU, string Titulo)
        {
            var resp = await apiEventosU.RegistrarEvento_Usuario(EveU);
            if(resp)
               await  DisplayAlert("Aviso", Titulo + " fue agregado a tus eventos!", "Ok");
            else
                await DisplayAlert("Aviso", "Error de conexión, intenta de nuevo", "Ok");
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