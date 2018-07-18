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
	public partial class Notificacion : ContentPage
	{
		public Notificacion ()
		{
			InitializeComponent ();
            destinatarios = new List<string>
            {
                "Charlistas",
                "Participantes"
            };
            pickerbtn.ItemsSource = destinatarios;
		}

        private List<string> destinatarios;

        private void pickerbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex > -1)
            {
                picker.SelectedItem.ToString();
            }
        }
    }
}