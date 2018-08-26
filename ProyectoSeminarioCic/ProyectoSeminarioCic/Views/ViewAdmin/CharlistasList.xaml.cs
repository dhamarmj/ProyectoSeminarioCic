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
    public partial class CharlistasList : ContentPage
    {
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        public string Titulo;
        public List<string> NameCharlista = new List<string>();
        public List<int> idCharlista = new List<int>();
        ObservableCollection<Charlistas> _charlistas;
        public List<Charlistas> _charlistasConfirmados;

        public CharlistasList()
        {
            InitializeComponent();
            Title = "Lista de Charlistas";
        }

        public class Charlistas
        {
            public Models.Usuario User { get; set; }
            public string NombreCompleto { get; set; }
            public Charlistas(Models.Usuario _user)
            {
                NombreCompleto = _user.Nombre + " " + _user.Apellido;
                User = _user;
            }
        }

        private async void LoadCharlistas()
        {
            var resp = await api.GetUsuario("Charlista");
            _charlistas = new ObservableCollection<Charlistas>();
            foreach (var item in resp)
            {
                _charlistas.Add(new Charlistas(item));
            }
            if(_charlistasConfirmados != null)
            {
                foreach (var item in _charlistasConfirmados)
                {
                    _charlistas.Insert(0, item);
                }
            }
            ListCharlistas.ItemsSource =   _charlistas;
            ListCharlistas.EndRefresh();
        }
        protected override void OnAppearing()
        {
            LblEvento.Text = "Evento: " + Titulo;
            LoadCharlistas();

        }

        private IEnumerable<Charlistas> SearchOption(string searchText)
        {
            if (_charlistas != null)
            {
                if (!string.IsNullOrWhiteSpace(searchText))
                    return _charlistas.Where(x => x.User.Nombre.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            return _charlistas;
        }

        private void ListCharlistas_Refreshing(object sender, EventArgs e)
        {
            LoadCharlistas();
        }
        public string returnCharlistas()
        {
            string V = string.Empty;
            if (NameCharlista.Count > 0)
            {

                foreach (string item in NameCharlista)
                {
                    V += item + ", ";
                }
                V = V.Remove(V.Length - 2);
            }

            return V;

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCharlistas.ItemsSource = SearchOption(e.NewTextValue);
        }

        private void ListCharlistas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var _charlista = e.SelectedItem as Charlistas;
            //if (_charlista != null)
            //{
            //    idCharlista = _charlista.User.Id;
            //    NameCharlista = _charlista.NombreCompleto;
            //    Navigation.PopAsync();
            //}

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var task = (sender as Switch).BindingContext as Charlistas;
            if (e.Value)
            {
                var i = _charlistas.IndexOf(task);
                _charlistas.Move(i, 0);
                NameCharlista.Add(task.NombreCompleto);
                idCharlista.Add(task.User.Id);
            }
            else
            {
                NameCharlista.Remove(task.NombreCompleto);
                idCharlista.Remove(task.User.Id);
            }
        }
    }
}