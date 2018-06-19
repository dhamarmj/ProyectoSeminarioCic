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
	public partial class Registro2 : ContentPage
	{
		public Registro2 ()
		{
			InitializeComponent ();
            btnconfirmar.Clicked += Btnconfirmar_Clicked;
		}

        async private void Btnconfirmar_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ViewGeneral.Login());
        }
    }
}