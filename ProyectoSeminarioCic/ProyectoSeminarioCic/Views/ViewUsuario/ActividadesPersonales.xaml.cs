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
    public partial class ActividadesPersonales : ContentPage
    {
        Services.ApiServices_EventoUsuario apiEventoU = new Services.ApiServices_EventoUsuario();
        Services.ApiServices_Eventos apiEventos = new Services.ApiServices_Eventos();
        ObservableCollection<Models.Evento> _eventos = new ObservableCollection<Models.Evento>();
        public ActividadesPersonales()
        {
            InitializeComponent();
          //  LoadEventos();
        }

        public async void LoadEventos()
        {
            var listE = await apiEventoU.GetEvento_Usuario(Settings.idUsuario);
            foreach (Models.Evento_Usuario i in listE)
            {
              //  if (_eventos.Where(x => x.Id == i.Id_evento) == null)
                    _eventos.Add(await apiEventos.GetEvento(i.Id_evento));
            }
            ListEventos.ItemsSource = _eventos;
            ListEventos.EndRefresh();
        }

        private void ListEventos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListEventos_Refreshing(object sender, EventArgs e)
        {
            LoadEventos();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}