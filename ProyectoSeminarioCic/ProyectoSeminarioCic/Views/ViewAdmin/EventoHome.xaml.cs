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
        Services.ApiServices_CharlaUsuario apiCharlaUsuario = new Services.ApiServices_CharlaUsuario();
        Services.ApiServices_EventoUsuario apiEventoUsuario = new Services.ApiServices_EventoUsuario();
        Services.ApiServices_Eventos api = new Services.ApiServices_Eventos();
        private ObservableCollection<Models.Evento> _eventos;
        public EventoHome()
        {
            InitializeComponent();

            var sem1 = new Models.Seminario { Titulo = "Seminario", Anio = new DateTime(2016, 06, 15), Descripcion = "ALGO" };

            LoadEvents();
            this.BindingContext = sem1;
            ListEvento.ItemsSource = _eventos;
        }

        public async void LoadEvents()
        {
            var list = await api.GetEventos();
            _eventos = new ObservableCollection<Models.Evento>(list);
            ListEvento.ItemsSource = _eventos;
            ListEvento.EndRefresh();
        }

        async private void Editar_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var eve = item.CommandParameter as Models.Evento;
            await Navigation.PushAsync(new CU_Evento(eve));
        }

        async private void Eliminar_Clicked(object sender, EventArgs e)
        {
            var eve = (sender as MenuItem).CommandParameter as Models.Evento;

            BtnLoading.IsRunning = true;
            var charla = await apiCharlaUsuario.GetCharla_Usuario(Convert.ToInt32(Settings.idUsuario), eve.Id);
            var evento = await apiEventoUsuario.GetEvento_Usuario(Convert.ToInt32(Settings.idUsuario), eve.Id);

            if (charla == null && evento == null)
            {
                var res = await DisplayAlert("Aviso", "Está a punto de eliminar un Evento, ¿Está seguro?", "Sí", "No");
                if (res)
                {
                    BtnLoading.IsRunning = true;
                    var respuesta = await api.EliminarEvento(eve.Id);
                    if (respuesta)
                    {
                        _eventos.Remove(eve);
                        await DisplayAlert("Éxito", "Evento eliminado", "Aceptar");
                    }
                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
                }

            }
            else
            {
                await DisplayAlert("Aviso", "Este Evento tiene participantes registrados y no se puede eliminar", "Ok");
            }

            BtnLoading.IsRunning = false;


        }

        async private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CU_Evento(null));
        }

        private void CambiarSeminario_Clicked(object sender, EventArgs e)
        {

        }

        private void ListEvento_Refreshing(object sender, EventArgs e)
        {
            LoadEvents();
        }
    }
}