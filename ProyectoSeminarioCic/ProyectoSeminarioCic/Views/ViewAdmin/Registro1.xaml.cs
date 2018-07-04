using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro1 : ContentPage
	{
		public Registro1 ()
		{
			InitializeComponent ();
            btnsiguiente.Clicked += Btnsiguiente_Clicked;
		}

        async private void Btnsiguiente_Clicked(object sender, EventArgs e)
        {
            //var usuario = new Models.Usuario
            //{
            //    Nombre = entrynom.Text, Apellido = entryapellido.Text, Fecha_Nacimiento = btnfecha.Date
            //};

          await Navigation.PushAsync(new Registro2(new Models.Usuario()));
        }
    }
}