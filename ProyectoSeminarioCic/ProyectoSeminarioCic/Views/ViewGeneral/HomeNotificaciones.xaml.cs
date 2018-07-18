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

            var notificaciones = new List<Notificacion>
            {
                new Notificacion{Titulo="Horario", Subtitulo="Horas de llegada al evento", Descripcion= "A good critic will refer back to the text often. You can find the full text of his speech on his Web site. the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts."},
                new Notificacion{Titulo="Vestimenta", Subtitulo="HHoras ", Descripcion="the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts."},
                new Notificacion{Titulo="no se ", Subtitulo="HHoras de", Descripcion = "the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts. the text of the Constitution The book is mostly photographs—it has very little text. At this point the Web site is only text. Graphics will be added later. Students will read and discuss various literary texts."},
                new Notificacion{Titulo="Otra cosa", Subtitulo="HHoras de llegada al "},
                new Notificacion{Titulo="Eto", Subtitulo=" de llegada al evento"},
                new Notificacion{Titulo="Aquello", Subtitulo="HHoras de  evento"}
            };
            listNotif.ItemsSource = notificaciones;
        }

        async private void ListNotif_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var notif = e.SelectedItem as Notificacion;
            await Navigation.PushAsync(new DetalleNotificaciones(notif));
            listNotif.SelectedItem = null;
        }
        
    }
}