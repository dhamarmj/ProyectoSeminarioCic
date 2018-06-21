using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleNotificaciones : ContentPage
	{
		public DetalleNotificaciones (Models.Notificacion notificacion)
		{
            if (notificacion == null)
                throw new ArgumentNullException();

			InitializeComponent ();
            this.BindingContext = notificacion;
		}
	}
}