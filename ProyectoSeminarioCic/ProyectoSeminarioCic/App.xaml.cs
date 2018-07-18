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
            MainPage =// new NavigationPage(new Views.ViewGeneral.Login());
              //  new Views.ViewAdmin.MainMenu();
            new Views.ViewGeneral.Home();
        }
        static Services.DbStartUp dbUtils;
        public static Services.DbStartUp DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new Services.DbStartUp();
                }
                Console.WriteLine(dbUtils.ReturnConnection());
                return dbUtils;
            }
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
