using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCIC.Views.ViewAdmin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerarClave : ContentPage
	{
		public GenerarClave ()
		{
			InitializeComponent ();
		}
        private void ButtonGenerador_Clicked(object sender, EventArgs e)
        {
            if (ClaveResultado.Text != "")
            {
                DisplayAlert("Clave ha sido generada", "", "Aceptar");

            }
            else
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$&";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                // DisplayAlert("Clave Generada", finalString, "Aceptar");
                ClaveResultado.Text = finalString;

            }
        }
        private void SaveGenerador_Clicked(object sender, EventArgs e)
        {
            //Update API

            //Clean After Update
            Username.Text = string.Empty;
            ClaveResultado.Text = string.Empty;
        }
    }
}