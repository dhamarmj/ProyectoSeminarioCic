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
            //Settings.AccesToken = "eeBQtHugj3HUUCoJMcXYG8dsPGKQ5zjVwB4LHNIxPY8rdjxNtuvw3H21_vNBevz89qZCD9-gygc-90YpxNHSqrSdfAby3PoSWl0L9m-MuQWn0nby50aurXAjgB1ahfhez4U4H41OMD9nxTYNxVMmWpry1mgm503mYEuGUCRAYNn8RmyMTPsHcDjg0rtEkfFmS_PQk3nOtLmvuvzpXBuuEDMhgyt94vrNI_CLadZepuLYa0lUfXcpAmBB23mfYblzPMGdgcCRgd9V42IZLHBcbpLYJkadPmOGWYrm4EXdDghK88tadpt6U6pNEdoyoPzCp42eeUHI4sUmQETUBhYrnkQ8uHggJ6wFq9o5n3E258-hBCIP_QUWXfezAN4OuHmo_ABNsCzk7u5FYl-dZfVA4Q-6COhnpXfTN07VYa3e76UxmpeXsjx08nTNWSsMaL3yF4OYclfzK-gkeNNRsNZSO_PES37AF0DRAYe4Z8r6RDvxK6PBeO-ODU06kmWci89z";
            //Settings.Email = "dhamarmj@ce.pucmm.edu.do";
            //Settings.Password = "Tarea.123";
            Settings.Rol = "Administrador";
           // Settings.idUsuario = "1";
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
