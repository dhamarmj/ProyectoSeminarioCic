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
    public partial class CU_Seminario : ContentPage
    {
        private Models.Seminario _seminario;
        public CU_Seminario(Models.Seminario se)
        {
           _seminario = se;
            InitializeComponent();
            this.BindingContext = _seminario;
        }

        private void AddLogo_Clicked(object sender, EventArgs e)
        {

        }
        private void Salvar_Clicked(object sender, EventArgs e)
        {

        }
    }
}