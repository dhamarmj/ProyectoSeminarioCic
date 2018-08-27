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
        //    Settings.AccesToken = Settings.Rol = Settings.Email = Settings.Password = Settings.idUsuario = string.Empty;
            Settings.AccesToken = "RfyO_HkJxK9CbeyTc75mOHiosUpWukw4WjAvoHbj5AtQlaZX_H_yzEiz0YuQ5JNLJl1-_lLMwf2xLkww3a-iCOIndYsly5AlOuCdwH1E3guo6lgTJTwyP_c4p-tQfRBJm1FMpinTz-RlnkFj--BJinFQf0vBKrLuvpC8IjyKhv2whz4Tw0P8MHnEjgK5ksclwgqUe9JsmfGAkpAMFDYz2wPWTU6lnQoMR4pvM-1YLkgOfC18yB8PBAYBZw_1RcD1ENZhuDohEthKyPRj4mXnOG8Vq5w_V6Pw4CJ37ONy0SUzlYxDm2a1sM2M_e3hlLDLUeL97eAXdT2Ti18uijcQ_QWGHukZ4pCW9KXPXukXXbGb7cOkNtNbz3TFREiUQ2L1coDP59e06wQfQYoQ9oyNZkJfeIwUYF3b9XKX1dChw0siYU9-dW1EyisxuG51S52mozD99yhtCitibltPRgvISYjOkJ1sW2pI1YfkvBSiOrf42m64Fl79RmPbr-ZKv4Gl";

            //Settings.Email = "dhamarmj@gmail.com";
            //Settings.Password = "Tarea.123";
            //Settings.Rol = "Administrador";
            //Settings.idSeminario = "1";
            //Settings.idBoleta = "1854545";
            //Settings.idUsuario = "2";

            if (!string.IsNullOrEmpty(Settings.idUsuario))
            {
                if (Settings.Rol == "Charlista" || (Settings.Rol == "Participante" && !string.IsNullOrEmpty(Settings.idBoleta)))
                {
                    MainPage = new Views.ViewGeneral.Home();
                }
                else if (Settings.Rol == "Participante" && string.IsNullOrEmpty(Settings.idBoleta))
                {
                    var nv = new NavigationPage(new Views.ViewUsuario.ScanHome());
                    nv.BarBackgroundColor = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
                    MainPage = nv;
                }
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
