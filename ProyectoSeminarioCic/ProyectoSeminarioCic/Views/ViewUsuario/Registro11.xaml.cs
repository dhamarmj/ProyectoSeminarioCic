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
	public partial class Registros11 : ContentPage
	{
		public Registros11 ()
		{
			InitializeComponent ();
           // this.BindingContext = new ViewModels.ViewModelUsuario();
		}

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List11());
        }
    }
}