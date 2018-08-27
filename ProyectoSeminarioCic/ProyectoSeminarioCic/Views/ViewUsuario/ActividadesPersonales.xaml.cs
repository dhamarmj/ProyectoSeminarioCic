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
           
        }

        protected override void OnAppearing()
        {
            LoadEventos();



        }
        public async void LoadEventos()
        {
            var listE = await apiEventoU.GetEvento_Usuario(Settings.idUsuario);
            foreach (Models.Evento_Usuario i in listE)
            {
                foreach (var item in listE)
                {
                    var exist = _eventos.FirstOrDefault(x => x.Id == item.Id);
                    if (exist == null)
                    {
                        var R = await apiEventos.GetEvento(item.Id_evento);
                        if (R != null)
                        {
                            _eventos.Add(R);
                        }
                    }
                }
            }
            ListEventos.ItemsSource = _eventos.OrderBy(x => x.Fecha);
            ListEventos.EndRefresh();
        }

        private void ListEventos_Refreshing(object sender, EventArgs e)
        {
            LoadEventos();
        }

        private void ListEventos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
          var evento = e.SelectedItem as Models.Evento;
            if (evento != null)
            {
                Navigation.PushAsync(new PreguntasHome(evento));
            }
        }
    }
}