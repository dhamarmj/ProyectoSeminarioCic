using AsNum.XFControls;
using Naxam.Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorarioParticipante : TopTabbedPage
    {
        public HorarioParticipante()
        {
            InitializeComponent();

            
            var P1 = new ViewGeneral.Page1() { Title = "VARIO"};
           
            var P2 = new ViewGeneral.Page1() { Title = "VARIO2" };
           
            Tab.Children.Add(P1);
            Tab.Children.Add(P2);
        }
       
    }
}