using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCIC.Views.ViewGeneral
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarDatos : ContentPage
	{
		public ActualizarDatos ()
		{
			InitializeComponent ();
            
        }
        private void SaveUpdate_Clicked(object sender, EventArgs e)
        {
            //Update API
        }

        private void CancelarUpdate_Clicked(object sender, EventArgs e)
        {
            //Cancelar
        }
    }
}