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
    public partial class MainMenu : MasterDetailPage
    {
        public MainMenu()
        {
            InitializeComponent();
            ContentP.BackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
            MenuTitle.BackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
            MyMenu();
        }
        public void MyMenu()
        {
            var start = new NavigationPage(new ViewGeneral.HomeFeed(true))
            {
                BarTextColor = Color.Black,
                BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.PrimaryColor)
            };
            Detail = start;
            List<Menu> menu = new List<Menu>
            {
                new Menu { Page = new ViewGeneral.HomeFeed(true), MenuTitle="Inicio", Icon = "baseline_home_black_36.png" },
                new Menu { Page = new ViewGeneral.HomePublicar(), MenuTitle="Publicar", Icon = "baseline_photo_camera_black_36.png" },
                new Menu { Page = new SeminarioHome(), MenuTitle="Seminarios", Icon = "baseline_event_available_black_36.png" },
                new Menu { Page = new EventoHome(), MenuTitle="Eventos", Icon = "baseline_event_note_black_36.png" },
                new Menu { Page = new Notificacion(), MenuTitle="Notificaciones",  Icon = "baseline_notifications_black_36.png" },
               new Menu { Page = new ViewGeneral.Profile(), MenuTitle="Perfil",  Icon = "baseline_person_black_36.png" },
                new Menu { Page = new ConfiguracionHome(), MenuTitle="Ajustes",  Icon = "baseline_settings_black_36.png" },
            };
            ListMenu.ItemsSource = menu;
        }
        public class Menu
        {
            public string MenuTitle { get; set; }

            public ImageSource Icon { get; set; }
            public Page Page { get; set; }
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                var start = new NavigationPage(menu.Page)
                {
                   BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.PrimaryColor)
                };
                Detail = start;

            }
        }
    }
}