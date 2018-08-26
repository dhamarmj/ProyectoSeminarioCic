using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewUsuario
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubirArchivos : ContentPage
	{
		public SubirArchivos ()
		{
			InitializeComponent ();
            btnselec.Clicked += Btnselec_Clicked;
            btnsubir.Clicked += Btnsubir_Clicked;
		}

        private async void Btnsubir_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "El archivo no se ha subido, pero tu ere jevi #HablamoAhorita", "Aceptar");
        }

        private  void Btnselec_Clicked(object sender, EventArgs e)
        {
            //var file = await CrossFilePicker.Current.PickFile();
            //if (file != null)
            //{
            //    lblarchivo.Text = file.FileName; 
            //}
            //lblarchivo.Text = file.FileName;
        }
    }
}