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
    public partial class Inicio : ContentPage
    {
        public Inicio ()
        {
            InitializeComponent();
            //TimePicker.e
            btnfecha.Clicked += Btnfecha_Clicked;
            
        }

        private void Btnfecha_Clicked(object sender, EventArgs e)
        {
            fechaview.DateSelected += Fechaview_DateSelected;
        }

        private void Fechaview_DateSelected(object sender, DateChangedEventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}