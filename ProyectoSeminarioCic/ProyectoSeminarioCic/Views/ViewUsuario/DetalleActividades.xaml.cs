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
	public partial class DetalleActividades : ContentPage
	{
        Models.Evento _evento;
		public DetalleActividades (Models.Evento eve)
		{
			InitializeComponent ();
            _evento = eve;
            Title = _evento.Titulo;
            this.BindingContext = _evento;

            if (TxtCharlista.Text != string.Empty)
                TxtCharlista.IsVisible = true;
		}
	}
}