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
	public partial class AgregarEvento : ContentPage
	{
        List<charlistas> charlistas;

        public AgregarEvento ()
		{            
			InitializeComponent ();
            Init();
            btnFoto.Clicked += BtnFoto_Clicked;
        }

        private void BtnFoto_Clicked(object sender, EventArgs e)
        {
        }

        private void Init()
        {
            charlistas = new List<charlistas>();
            charlistas.Add(new charlistas { nombre = "Alberto", apellido = "Castro" });
            charlistas.Add(new charlistas { nombre = "Flor", apellido = "Martinez" });
            charlistas.Add(new charlistas { nombre = "Gilberto", apellido = "Rosa" });
            charlistas.Add(new charlistas { nombre = "Amanda", apellido = "Jimenza" });
            charlistas.Add(new charlistas { nombre = "Karol", apellido = "Peralta" });
            charlistas.Add(new charlistas { nombre = "Antonio", apellido = "Ortega" });
            charlistas.Add(new charlistas { nombre = "Casemiro", apellido = "Vidal" });
            charlistas.Add(new charlistas { nombre = "Pedro", apellido = "Olivas" });
            foreach (var charlista in charlistas)
            {
                pickerbtn.Items.Add(charlista.nombre + " " + charlista.apellido);
            }
        }
        
        private void pickerbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posicion = pickerbtn.SelectedIndex;
            if(posicion > -1){
            }
        }
    }
}