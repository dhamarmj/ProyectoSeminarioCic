using System;
using Xamarin.Forms;
using ProyectoSeminarioCic.Views;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Views.ViewUsuario;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ProyectoSeminarioCic
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new Views.ViewGeneral.HomeNotificaciones());
            MainPage = new Views.ViewCharlista.HorarioCharlistas();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
