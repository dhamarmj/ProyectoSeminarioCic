using System;
using Xamarin.Forms;
using ProyectoSeminarioCic.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProyectoSeminarioCic
{
    public partial class App : Application
    {
        static Services.DbStartUp dbUtils;
        public App()
        {
            InitializeComponent();

            try
            {
                dbUtils = new Services.DbStartUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("APP");
                Console.WriteLine(ex.ToString());
            }
            

            MainPage = new NavigationPage(new Views.ViewAdmin.Registro2(new Models.Usuario()));
            //MainPage = new NavigationPage(new Views.ViewGeneral.Login());  
        }
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
