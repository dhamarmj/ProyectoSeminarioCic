using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class HomeNotificaciones : ContentPage
	{
		public HomeNotificaciones ()
		{
			InitializeComponent ();

            var notificaciones = new List<NotificacionModel>
            {
                new NotificacionModel{titulo="Horario", subtitulo="Horas de llegada al evento", descripcion= "A good critic will refer back to the text often. You can find the full text of his speech on his Web site. the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts."},
                new NotificacionModel{titulo="Vestimenta", subtitulo="HHoras ", descripcion="the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts."},
                new NotificacionModel{titulo="no se ", subtitulo="HHoras de", descripcion = "the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts. the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts."},
                new NotificacionModel{titulo="Otra cosa", subtitulo="HHoras de llegada al "},
                new NotificacionModel{titulo="Eto", subtitulo=" de llegada al evento"},
                new NotificacionModel{titulo="Aquello", subtitulo="HHoras de  evento"}
            };
            listNotif.ItemsSource = notificaciones;
		}

        async private void listNotif_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var notif = e.SelectedItem as NotificacionModel;
            await Navigation.PushAsync(new DetalleNotificaciones(notif));
            listNotif.SelectedItem = null;
        }

        async private void ButtonHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeFeed());

        }

        private void ButtonNotifications_Clicked(object sender, EventArgs e)
        {

        }

        private void ButtonPost_Clicked(object sender, EventArgs e)
        {

        }

        private void ButtonSchedule_Clicked(object sender, EventArgs e)
        {

        }

        private void ButtonConfiguration_Clicked(object sender, EventArgs e)
        {

        }
    }
}