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
    public partial class List11 : ContentPage
    {
        public List11()
        {
            InitializeComponent();
            var consult = (new ViewModels.ListadoViewModelUsuario()).ListadoUsuario;
            if (consult == null)
                Console.WriteLine("NULL");
            else
                listUsuario.ItemsSource = consult;

        }
    }
}