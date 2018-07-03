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
        ObservableCollection<Pregunta> PreguntasL { get; set; }

        public DetallePreguntas()
        {
            InitializeComponent();
            PreguntasL = new ObservableCollection<Pregunta>
            {
                new Pregunta{ PreguntaText ="ETO o lo otro que yo queria preguntar?", ImagenUsuario="http://placeimg.com/100/100/people/1",NombreUsuario="Morgan" },
                new Pregunta { PreguntaText = "Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by ?", ImagenUsuario = "http://placeimg.com/100/100/people/2", NombreUsuario = "MorganA" },
                new Pregunta { PreguntaText = "ETO o l queria preguntar?", ImagenUsuario = "http://placeimg.com/100/100/people/3", NombreUsuario = "MorganB" },
                new Pregunta { PreguntaText = "ETO o lo otro que y preguntar?", ImagenUsuario = "http://placeimg.com/100/100/people/4", NombreUsuario = "MorganC" },
                new Pregunta { PreguntaText = "ETO o lo otro que yo queria preguntar?", ImagenUsuario = "http://placeimg.com/100/100/people/5", NombreUsuario = "MorganD" },
            };

            listPregunta.ItemsSource = PreguntasL;
        }


        private void answered_Clicked(object sender, EventArgs e)
        {
            //listPregunta.ItemSelected += new EventHandler<SelectedItemChangedEventArgs>(listPregunta_ItemSelected);
            //listPregunta_ItemSelected(sender, new SelectedItemChangedEventArgs(e.));
            //DisplayAlert("OK", "OK", "OK");
        }

        private void listPregunta_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var p = e.SelectedItem as Pregunta;
            //var index = PreguntasL.IndexOf(PreguntasL.Where(x => x.PreguntaText == p.PreguntaText).FirstOrDefault());
            //PreguntasL.RemoveAt(index);
            //PreguntasL.Insert(PreguntasL.Count, p);
            //listPregunta.ItemsSource = PreguntasL;
        }

        private void listPregunta_Refreshing(object sender, EventArgs e)
        {
            //PreguntasL.Add(new Pregunta { PreguntaText = "ETO o lo otro que yo queria preguntar?", ImagenUsuario = "http://placeimg.com/100/100/people/1", NombreUsuario = "Morgan1" });

            //DisplayAlert("OK", PreguntasL.Count.ToString(), "OK");
            ////var p = preg[2];
            ////var index = preg.FindIndex(x => x.PreguntaText == p.PreguntaText);
            ////preg.Add(p);
            ////preg.RemoveAt(index);
            //listPregunta.ItemsSource = PreguntasL;
            //listPregunta.IsRefreshing = false;
        }

        private void answered_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}