﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;

namespace ProyectoSeminarioCic.Views.ViewCharlista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class HomeNotificaciones : ContentPage
	{
		public HomeNotificaciones ()
		{
			InitializeComponent ();

            var notificaciones = new List<NotificacionModel>
            {
                new NotificacionModel{titulo="Horario", subtitulo="Horas de llegada al evento"},
                new NotificacionModel{titulo="Vestimenta", subtitulo="HHoras "},
                new NotificacionModel{titulo="no se ", subtitulo="HHoras de"},
                new NotificacionModel{titulo="Otra cosa", subtitulo="HHoras de llegada al "},
                new NotificacionModel{titulo="Eto", subtitulo=" de llegada al evento"},
                new NotificacionModel{titulo="Aquello", subtitulo="HHoras de  evento"}
            };
            listNotif.ItemsSource = notificaciones;
		}

        private void listNotif_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listNotif.SelectedItem = null;
        }

        async private void ButtonHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeCharlistas());

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