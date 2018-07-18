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
		public Home ()
		{
			InitializeComponent ();
            NavigationPage P1 = new NavigationPage(new HomeFeed(false));
            P1.BarBackgroundColor = Color.LightSlateGray;
            P1.Icon = "baseline_home_black_36.png";
            NavigationPage P2 = new NavigationPage(new HomeNotificaciones());
            P2.BarBackgroundColor = Color.LightSlateGray;
            P2.Icon = "baseline_notifications_black_36.png";
            NavigationPage P3 = new NavigationPage(new Page1());
            P3.BarBackgroundColor = Color.LightSlateGray;
            P3.Icon = "baseline_photo_camera_black_36.png";
            NavigationPage P4 = new NavigationPage(new ViewCharlista.HorarioCharlistas());
            P4.BarBackgroundColor = Color.LightSlateGray;
            P4.Icon = "baseline_schedule_black_36.png";
            NavigationPage P5 = new NavigationPage(new Page1());
            P5.BarBackgroundColor = Color.LightSlateGray;
            P5.Icon = "baseline_person_black_36.png";
            Tab.Children.Add(P1);
            Tab.Children.Add(P2);
            Tab.Children.Add(P3);
            Tab.Children.Add(P4);
            Tab.Children.Add(P5);
        }
	}
}