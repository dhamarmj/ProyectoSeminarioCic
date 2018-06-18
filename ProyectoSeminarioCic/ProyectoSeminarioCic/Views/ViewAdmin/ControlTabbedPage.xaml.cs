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
    public partial class ControlTabbedPage : TabbedPage
    {
        public ControlTabbedPage ()
        {
            InitializeComponent();
            Children.Add(new Inicio());
            Children.Add(new EventosAdmin());
            Children.Add(new Publicacion());
            Children.Add(new Notificacion());
            Children.Add(new Configuracion());

        }
    }
}