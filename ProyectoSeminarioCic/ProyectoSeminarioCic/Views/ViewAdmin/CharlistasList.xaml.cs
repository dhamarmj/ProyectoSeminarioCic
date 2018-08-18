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
        public CharlistasList()
        {
            InitializeComponent();
            LoadCharlistas();
        }
        public string NameCharlista;
        public int idCharlista;
        ObservableCollection<Charlistas> _charlistas;
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

            ListCharlistas.ItemsSource = _charlistas;
            ListCharlistas.EndRefresh();
        }
        

        private IEnumerable<Charlistas> SearchOption(string searchText)
        {
            if (_charlistas != null)
            {
                if (!string.IsNullOrWhiteSpace(searchText))
                    return _charlistas.Where(x => x.User.Nombre.StartsWith(searchText)).ToList();
            }
            return _charlistas;
        }
        private void ListCharlistas_Refreshing(object sender, EventArgs e)
        {
            LoadCharlistas();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCharlistas.ItemsSource = SearchOption(e.NewTextValue);
        }

        private void ListCharlistas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var _charlista = e.SelectedItem as Charlistas;
            if (_charlista != null)
            {
                idCharlista = _charlista.User.Id;
                NameCharlista = _charlista.NombreCompleto;
                Navigation.PopAsync();
            }
                
        }
    }
}