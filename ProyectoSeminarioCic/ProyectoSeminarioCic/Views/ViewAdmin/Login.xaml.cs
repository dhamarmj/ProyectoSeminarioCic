using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
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
            await Navigation.PushAsync(new Registro1());
        }

        async private void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            if (nombre.Text == "dhamarmj")
            {
                await Navigation.PushModalAsync(new Views.ViewCharlista.HomeCharlistas());
            }
            else
                await Navigation.PushModalAsync(new ControlTabbedPage());

        }
    }
}