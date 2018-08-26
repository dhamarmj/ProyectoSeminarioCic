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
        Services.ApiServices_EventoUsuario apiEventoUsuario = new Services.ApiServices_EventoUsuario();
        Services.ApiServices_Eventos api = new Services.ApiServices_Eventos();
        Services.ApiServices_Seminario apiSeminario = new Services.ApiServices_Seminario();
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        private ObservableCollection<Models.Evento> _eventos;
        string opcion = "INSERTAR";
        public EventoHome()
        {
            InitializeComponent();
            LoadSeminario();
            //  LoadEvents();
        }
        protected override void OnAppearing()
        {
            if (opcion == "INSERTAR")
            {
                LoadEvents();
                opcion = "";
            }
                
        }
        private async void LoadSeminario()
        {
            BtnLoading.IsRunning = true;
            var sem = await apiSeminario.GetSeminario(Convert.ToInt32(Settings.idSeminario));
            this.BindingContext = sem;
            BtnLoading.IsRunning = false;
        }
        public async void LoadEvents()
        {
            BtnLoading.IsRunning = true;
            var list = await api.GetEventos(Convert.ToInt32(Settings.idSeminario));
            _eventos = new ObservableCollection<Models.Evento>(list);
            ListEvento.ItemsSource = _eventos;
            ListEvento.EndRefresh();
            BtnLoading.IsRunning = false;
        }

        async private void Editar_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var eve = item.CommandParameter as Models.Evento;

            await Navigation.PushAsync(new CU_Evento(eve));
        }

        private async void UpdateUsuario(int idE)
        {
            var E = await apiUsuario.GetUsuario(idE,0);
            if(E.Count > 0)
            {
                foreach (var item in E)
                {
                    item.Id_evento = 0;
                    var R = await apiUsuario.ActualizarUsuario(item);
                }
            }
            
        }

        async private void Eliminar_Clicked(object sender, EventArgs e)
        {
            var eve = (sender as MenuItem).CommandParameter as Models.Evento;

            BtnLoading.IsRunning = true;
            var evento = await apiEventoUsuario.GetEvento_Usuario(Convert.ToInt32(Settings.idUsuario), eve.Id);

            if (evento == null)
            {
                var res = await DisplayAlert("Aviso", "Está a punto de eliminar un Evento, ¿Está seguro?", "Sí", "No");
                if (res)
                {
                    BtnLoading.IsRunning = true;
                    var respuesta = await api.EliminarEvento(eve.Id);
                    if (respuesta)
                    {
                       UpdateUsuario(eve.Id);

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
            opcion = "INSERTAR";
            await Navigation.PushAsync(new CU_Evento(null));
        }

        private void ListEvento_Refreshing(object sender, EventArgs e)
        {
            LoadEvents();
        }

    }
}