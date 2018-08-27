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
    public partial class DetalleActividades : ContentPage
    {
        Models.Evento _evento;
        Services.ApiServices_Usuario api = new Services.ApiServices_Usuario();
        public DetalleActividades(Models.Evento eve)
        {
            InitializeComponent();
            _evento = eve;
            Title = _evento.Titulo;
            this.BindingContext = _evento;
            LoadCharlista();
        }

        private async void LoadCharlista()
        {
            BtnLoading.IsRunning = true;
            var R = await api.GetUsuario(_evento.Id, 0);
            if (R.Count > 0)
            {
                TxtCharlista.Text = "";
                foreach (var item in R)
                {
                    TxtCharlista.Text += item.Nombre + " " + item.Apellido + ", ";
                }

                TxtCharlista.Text = TxtCharlista.Text.Remove(TxtCharlista.Text.Length - 2);
            }
            else
                header.IsVisible = LblCharlistas.IsVisible = TxtCharlista.IsVisible = false;

            BtnLoading.IsRunning = false;
        }

    }
}