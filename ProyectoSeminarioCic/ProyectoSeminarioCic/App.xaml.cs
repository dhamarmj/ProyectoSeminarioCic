using System;
using Xamarin.Forms;
using ProyectoSeminarioCic.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProyectoSeminarioCic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Settings.AccesToken = "6XVlscyrJcQb4NyBgX7FKoMZFbVNOvNoWe0DxcyG_pVogYAhRvh9wwILHzDGxvOb_7xKIj22h3SNg-j7CKjkLg3SfMcuB402ZPOlz-kFSnkfc5pC4MHXT8oHsyEupsuiWlAgGvzNr5glSl5FvWsROLpTqaktIRH6T_XWzc6pS2Fz_cu8F8MaDyE8Wx5m6EU_nFnGtB5uGA4A8rkLousUIvoLq5cW89MsIW_AOIcImkQ4gzuDE1ew0i5a7d9cRjl0vXS89YA2gNqBfDc7RoRG49ShRKbVgnwrLL8pD7p-jDgOlzZxByHCu_AgtAw-jPgnFsI0SwqsioAkak1wnhmRcL8bpcFmfxiwla_FvRh2Xc_EFg2YGTEcN67Iwghmo-CT2ZDIYaA-VWytvAvNRcKyUHXlysv8VWJgengIXM7oO_a4e48vgTgh8ntY0yHA3ObKNG2GbSgi5EcLX58rgkI5yJnmBTqMzuKDmESmnz2ME0mA2z3X5t8jeWrf_2cAr8Ia";
            //Settings.Email = "dhamarmj@gmail.com";
            //Settings.Password = "Tarea.123";
            // Settings.Rol = "Participante";
            //Settings.idUsuario = "1";
            //Settings.AccesToken = Settings.Rol = Settings.Email = Settings.Password = Settings.idUsuario = string.Empty;
            //Settings.idSeminario = "1";
            //Settings.idBoleta = string.Empty;
            
            if (!string.IsNullOrEmpty(Settings.AccesToken))
            {
                if (Settings.Rol == "Charlista" || (Settings.Rol == "Participante" && !string.IsNullOrEmpty(Settings.idBoleta)))
                {
                    MainPage = new Views.ViewGeneral.Home();
                }
                else if (Settings.Rol == "Participante" && string.IsNullOrEmpty(Settings.idBoleta))
                {
                    MainPage = new NavigationPage(new Views.ViewUsuario.ScanHome());
                }
                else
                {
                    MainPage = new Views.ViewAdmin.MainMenu();
                }
            }
            else
            {
                var nv = new NavigationPage(new Views.ViewGeneral.Login());
                nv.BarBackgroundColor = Color.SlateGray;
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
