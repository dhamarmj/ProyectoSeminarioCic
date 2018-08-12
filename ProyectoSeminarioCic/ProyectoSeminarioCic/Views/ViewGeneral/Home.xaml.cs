using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : Naxam.Controls.Forms.BottomTabbedPage
    {
        public Home(string rol)
        {
            InitializeComponent();
            NavigationPage P1 = new NavigationPage(new HomeFeed(false))
            {
                BarBackgroundColor = Color.LightSlateGray,
                Icon = "baseline_home_black_36.png"
            };
            NavigationPage P2 = new NavigationPage(new HomeNotificaciones())
            {
                BarBackgroundColor = Color.LightSlateGray,
                Icon = "baseline_notifications_black_36.png"
            };
            NavigationPage P3 = new NavigationPage(new Page1())
            {
                BarBackgroundColor = Color.LightSlateGray,
                Icon = "baseline_photo_camera_black_36.png"
            };
            Page P4 = null;
            if (rol == "Charlista")
            {
                P4 = new NavigationPage(new ViewCharlista.HorarioCharlistas())
                {
                    BarBackgroundColor = Color.LightSlateGray,
                    Icon = "baseline_schedule_black_36.png"
                };
            }
            else if (rol == "Participante")
            {
                P4 = new NavigationPage(new ViewUsuario.HorarioParticipante())
                {
                    BarBackgroundColor = Color.LightSlateGray,
                    Icon = "baseline_schedule_black_36.png"
                };
            }

            NavigationPage P5 = new NavigationPage(new Page1())
            {
                BarBackgroundColor = Color.LightSlateGray,
                Icon = "baseline_person_black_36.png"
            };
            Tab.Children.Add(P1);
            Tab.Children.Add(P2);
            Tab.Children.Add(P3);
            Tab.Children.Add(P4);
            Tab.Children.Add(P5);
        }
    }
}