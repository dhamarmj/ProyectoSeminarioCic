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
    public partial class CU_Evento : ContentPage
    {
        private Models.Evento _Evento;
        public CU_Evento(Models.Evento eve)
        {
            _Evento = eve;
            InitializeComponent();
            Init();
            if (_Evento.Titulo == null)
                LblDescrip.IsVisible = false;
            this.BindingContext = _Evento;
        }

        List<charlistas> charlistas;
        private void Init()
        {
            charlistas = new List<charlistas>()
            {
                new charlistas { nombre = "Alberto", apellido = "Castro" },
                new charlistas { nombre = "Flor", apellido = "Martinez" },
                new charlistas { nombre = "Gilberto", apellido = "Rosa" },
                new charlistas { nombre = "Amanda", apellido = "Jimenza" },
                new charlistas { nombre = "Karol", apellido = "Peralta" },
                new charlistas { nombre = "Antonio", apellido = "Ortega" },
                new charlistas { nombre = "Casemiro", apellido = "Vidal" },
                new charlistas { nombre = "Pedro", apellido = "Olivas" }
            };
            pickerbtn.ItemsSource = charlistas;

        }
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