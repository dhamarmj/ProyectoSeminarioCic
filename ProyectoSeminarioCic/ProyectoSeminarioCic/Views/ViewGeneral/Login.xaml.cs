using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            btnIniciar.Clicked += BtnIniciar_Clicked;
            btnreg.Clicked += Btnreg_Clicked1;
        }

        async private void Btnreg_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewGeneral.Registro1()));
        }

         private void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            //if (nombre.Text == "dhamarmj")
            //{
            //    await Navigation.PushModalAsync(new ViewGeneral.HomeFeed());
            //}
            //else
            //    await Navigation.PushModalAsync(new ViewAdmin.ControlTabbedPage());

        }
    }
}