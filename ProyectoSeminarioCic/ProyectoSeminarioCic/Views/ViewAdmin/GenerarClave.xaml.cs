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
                var charsALL = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@$%.,";
                var randomIns = new Random();
                int N = 8;
                var rndChars = Enumerable.Range(0, N)
                                .Select(_ => charsALL[randomIns.Next(charsALL.Length)])
                                .ToArray();
                rndChars[randomIns.Next(rndChars.Length)] = "0123456789"[randomIns.Next(10)];

                var randomstr = new String(rndChars);
                ClaveResultado.Text = randomstr;


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