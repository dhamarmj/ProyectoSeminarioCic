using Naxam.Controls.Forms;
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
    public partial class HorarioParticipante : TopTabbedPage
    {
        public HorarioParticipante ()
        {
            InitializeComponent();
            Title = "Horario";

            BarTextColor = Color.White;
            BarIndicatorColor = Color.FromHex(Proyecto.CurrrentSeminar.PrimaryColor);
            BarBackgroundColor = Color.FromHex("#094C68");

            var P1 = new HorarioActividades() { Title = "Actividades" };
            var P2 = new ActividadesPersonales() { Title = "Mi Horario" };

            Tab.Children.Add(P1);
            Tab.Children.Add(P2);
        }
    }
}