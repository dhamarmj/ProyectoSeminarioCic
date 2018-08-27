using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracionHome : ContentPage
    {
        public ConfiguracionHome()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            StartConfig();
        }
        private void StartConfig()
        {
            var conf = new List<ConfigItems>
            {
                new ConfigItems{ Page = new GenerarClave(), Titulo="Contraseñas Especiales", Descrip = "Para registrar charlistas y personal", Icon = "key.png" },
                //new ConfigItems{ Page = new ViewGeneral.Page1(), Titulo="Cambiar Logo Seminario", Descrip = "Para toda la aplicación", Icon = "password.png" }
            };

            ListConf.ItemsSource = conf;
        }

        public class ConfigItems
        {
            public string Titulo { get; set; }
            public string Descrip { get; set; }
            public ImageSource Icon { get; set; }
            public Page Page { get; set; }
        }

        async private void ListConf_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as ConfigItems;
            if (menu != null)
            {

                await Navigation.PushAsync(menu.Page);
            }
        }
    }
}