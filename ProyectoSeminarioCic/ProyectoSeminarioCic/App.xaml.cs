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
            Settings.AccesToken = "zxPfMWZ59HhnhmLNqYp_Ez2ip4O2aoj6poUY0iYK3KMLy7On9e0PVm1288GRqs8RTAfYhPwt8e2MYI4W2ZNC3oItyIMeVxtm4aQfmmZ7TGeiqbLrs68zj - TYRFq - ZOE - BDpaDZuRqbNAqASjGz9K88AoYRfwW8mdRWkXmHyDCCi5LU8XRwbGAezIXgB_QogFM9wsDbj6LLXAjIiDy_Dd3OzELvJL4fbCtc8gwC7xKdgA2OQBwuUXwcPhnFbBM0GkLsLt4anW3fLS3 - j0bN8xPvTdvXtYh1x10y1ScrGXxuA - uffQg1yDHIj2Jk48MSaKalvRDJldDhMyhOe7dVJNtFmoWKzLGy_2Q - A0yVF - VTd_Oh2_xQueKuitE82KGy2WEvITM5YRRHrYjy40DjXBTdDuPkzV0KEOi_jsEVTLzoRbRR2c_sNDBUKOOcUE0rrkIHM_5Y_0ccOJx13ErUCHWhdqDukeaA - 5twSNVD5YIgnH8eg2TL82HMPYhdbBz8ab";
            Settings.Email = "dhamarmj@ce.pucmm.edu.do";
            Settings.Password = "Tarea.123";
            Settings.Rol = "Administrador";
            //MainPage = new Views.ViewAdmin.MainMenu();
            // MainPage = new Views.ViewGeneral.Home("Participante");
            //Settings.AccesToken = Settings.Email = Settings.Password = Settings.Rol = string.Empty;
            if (!string.IsNullOrEmpty(Settings.AccesToken))
            {
                if (Settings.Rol == "Charlista" || Settings.Rol == "Participante")
                {
                    MainPage = new Views.ViewGeneral.Home(Settings.Rol);
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
            // new NavigationPage(new Views.ViewGeneral.Login());
            //  new Views.ViewAdmin.MainMenu();
            // new Views.ViewGeneral.Home();

        }
        //static Services.DbStartUp dbUtils;
        //public static Services.DbStartUp DAUtil
        //{
        //    get
        //    {
        //        if (dbUtils == null)
        //        {
        //            dbUtils = new Services.DbStartUp();
        //        }
        //        Console.WriteLine(dbUtils.ReturnConnection());
        //        return dbUtils;
        //    }
        //}
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
