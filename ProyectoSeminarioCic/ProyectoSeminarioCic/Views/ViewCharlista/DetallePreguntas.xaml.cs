using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewCharlista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePreguntas : ContentPage
    {
        ObservableCollection<Pregunta> PreguntasL = new ObservableCollection<Pregunta>();
        Services.ApiServices_Preguntas apiPreguntas = new Services.ApiServices_Preguntas();
        Services.ApiServices_Usuario apiUsuarios = new Services.ApiServices_Usuario();
        Services.ApiServices_EventoUsuario apiEveu = new Services.ApiServices_EventoUsuario();
        int IdCharla;
        public DetallePreguntas(int Id)
        {
            InitializeComponent();
            IdCharla = Id;
            loadPreguntas();
            listPregunta.ItemsSource = PreguntasL;
        }
        public class Pregunta
        {
            public string Texto { get; set; }
            public int id_Usuario { get; set; }
            public string ImagenUsuario { get; set; }
            public string Username { get; set; }
        }

        private async void loadPreguntas()
        {
            BtnLoading.IsRunning = true;
            var value = await apiEveu.GetEvento_Usuario(IdCharla);
            foreach (var item in value)
            {
                var c = await apiPreguntas.GetPregunta(item.Id.ToString());
                if (c != null)
                    PreguntasL.Add(new Pregunta { id_Usuario = item.Id_usuario, Texto = c.Texto });
            }
            foreach (var item in PreguntasL)
            {
                var a = await apiUsuarios.GetUsuario(item.id_Usuario);
                item.Username = a.Username;
                item.ImagenUsuario = a.FotoPath;
            }
            BtnLoading.IsRunning = false;
        }
        private void listPregunta_Refreshing(object sender, EventArgs e)
        {
            loadPreguntas();
        }

        private void answered_Toggled(object sender, ToggledEventArgs e)
        {
            var task = (sender as Switch).BindingContext as Pregunta;
            if (e.Value)
            {
                var i = PreguntasL.IndexOf(task);
                PreguntasL.Move(i, PreguntasL.Count-1);
            }
        }
    }
}