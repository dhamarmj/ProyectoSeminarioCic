using System;
using Xamarin.Forms;
using ProyectoSeminarioCic.Views;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Threading;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProyectoSeminarioCic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var userSelectedCulture = new CultureInfo("es-DO");
            Thread.CurrentThread.CurrentCulture = userSelectedCulture;

            // Settings.Rol = Settings.Email = Settings.Password = Settings.idUsuario = string.Empty;

            Settings.AccesToken = "mHX4gEzalI7Dr1Rn_FDiSm1QlQ5FX9srLpCZv525oaIoaxo7T3vYl-DzXvWwOop1b34YTqK363Wo-ImFMPXE699xxr2dDrURLW74f6pNWKE2z2y0yp3dA_CY3JIczGYAnaszXY_fs0ArBVFpNI2HEOKZrkd7aRmLJUoBMRos8ersvRUfaQ3eOxO3Su1trrY-ObjPLFN1yfB0sQCBy_sgmoEFAbB1AbcgaDE1heVXYTKhTzkNbe-iioMx6jGAhKbfXQxqU25ifPfK46t69_4UtbH7c9z9srTEshMP6t8FsnPXMpb24U9heNd3qt2YjePPE2EhSyNWgxJFNOxkcc1dp6bCp6ID6oKUMDA_gxgcxApdspNgzwJiNFrI_HHNM7tHcRagQC5UAlw43TuwjjcIeFf2vAeZBqWqWG4inFr53MvzA8KfUu-zaAWs4J9P2zPKrGT_hNuxBg-34uQnouUo40iROxKWDOlTAhqviH3oS-SP9Z9oYrBzHyWiAEHtUFJd";

            Settings.Email = "dhamarmj@hotmail.com";
            Settings.Password = "Tarea.123";
            Settings.Rol = "Charlista";
            Settings.idSeminario = "1";
            //  Settings.idBoleta = "1854545";
            Settings.idUsuario = "1";


            //Settings.Email = "edgarn@hotmail.com";
            //Settings.Password = "Telefono.123";
            //Settings.Rol = "Participante";
            //Settings.idSeminario = "1";
            //Settings.idBoleta = "1854545";
            //Settings.idUsuario = "5";


            if (!string.IsNullOrEmpty(Settings.idUsuario))
            {
                if (Settings.Rol == "Charlista" || (Settings.Rol == "Participante")) // && !string.IsNullOrEmpty(Settings.idBoleta)))
                {
                    MainPage = new Views.ViewGeneral.Home();
                }
                ////else if (Settings.Rol == "Participante" && string.IsNullOrEmpty(Settings.idBoleta))
                ////{
                ////    var nv = new NavigationPage(new Views.ViewUsuario.ScanHome());
                ////    nv.BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
                ////    MainPage = nv;
                ////}
                else
                {
                    MainPage = new Views.ViewAdmin.MainMenu();
                }
            }
            else
            {
                var nv = new NavigationPage(new Views.ViewGeneral.Login());
                nv.BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
                MainPage = nv;
            }
            //   MainPage = new Views.ViewGeneral.Page1();
            ////new NavigationPage(new Views.ViewGeneral.Login());
            ////new Views.ViewAdmin.MainMenu();
            ////new Views.ViewGeneral.Home();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
