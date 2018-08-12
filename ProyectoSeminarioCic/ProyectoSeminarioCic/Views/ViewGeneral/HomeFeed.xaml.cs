using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;
namespace ProyectoSeminarioCic.Views.ViewGeneral
{

    public partial class HomeFeed : ContentPage
    {
        bool NavBar;
        public HomeFeed(bool hasNavigationBar)
        {
            NavBar = hasNavigationBar;
            InitializeComponent();
            if (hasNavigationBar)
            {
                HeaderBar.IsVisible = HeaderText.IsVisible = HeaderSeparator.IsVisible = false;
                listPictures1.IsVisible = true;
                listPictures1.ItemsSource = StartView();
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, hasNavigationBar);
                listPictures.IsVisible = true;
                listPictures.ItemsSource = StartView();
            }

        }

        private List<Publicacion> StartView()
        {

            return new List<Publicacion>()
            {
                new Publicacion { nombreUsuario="Mosh", caption= "Something Deep",  imagenPerfil = "http://placeimg.com/100/100/people/1" , numComent = "1", numKaip = "15", imagenPublicacion="http://placeimg.com/480/280/animals/1", comments = new List<Comentario>()
            {
                new Comentario {nombreUsuario="Fulano", comentario= "this girl is on FIRE and some more text p aue la vaina se ponga buena pa ve si e dd", imagenUsuario="http://placeimg.com/100/100/people/5"}
            }},
                new Publicacion { nombreUsuario="Josh", caption= "Something Meaningfull", imagenPerfil = "http://placeimg.com/100/100/people/2" , numComent = "2", numKaip = "20", imagenPublicacion="http://placeimg.com/480/280/arch", comments = new List<Comentario>()
            {
                new Comentario {nombreUsuario="Fulana", comentario= "this girl is on WATER", imagenUsuario="http://placeimg.com/100/100/people/6"},
                new Comentario {nombreUsuario="Ful", comentario= "this boy is on FIRE", imagenUsuario="http://placeimg.com/100/100/people/5"}
            }
    },
                new Publicacion { nombreUsuario="Molly", caption= "Something Else", imagenPerfil = "http://placeimg.com/100/100/people/3" , numComent = "3", numKaip = "5", imagenPublicacion="http://placeimg.com/480/280/nature", comments = new List<Comentario>()
            {
                new Comentario {nombreUsuario="ulano", comentario= "this boy is on WATER", imagenUsuario="http://placeimg.com/100/100/people/7"},
                new Comentario {nombreUsuario="Fulano", comentario= "this girl is on FIRE", imagenUsuario="http://placeimg.com/100/100/people/7"},
                new Comentario {nombreUsuario="Fulana", comentario= "this girl is on WATER", imagenUsuario="http://placeimg.com/100/100/people/8"},
                 new Comentario {nombreUsuario="Fulana", comentario= "this girl is on WATER", imagenUsuario="http://placeimg.com/100/100/people/6"},
                new Comentario {nombreUsuario="Ful", comentario= "this boy is on FIRE", imagenUsuario="http://placeimg.com/100/100/people/5"},
                new Comentario {nombreUsuario="ulano", comentario= "this boy is on WATER", imagenUsuario="http://placeimg.com/100/100/people/7"},
                new Comentario {nombreUsuario="Fulano", comentario= "this girl is on FIRE", imagenUsuario="http://placeimg.com/100/100/people/7"},
                new Comentario {nombreUsuario="Fulana", comentario= "this girl is on WATER", imagenUsuario="http://placeimg.com/100/100/people/8"},
                 new Comentario {nombreUsuario="Fulana", comentario= "this girl is on WATER", imagenUsuario="http://placeimg.com/100/100/people/6"},
                new Comentario {nombreUsuario="Ful", comentario= "this boy is on FIRE", imagenUsuario="http://placeimg.com/100/100/people/5"},

            }
    },
                new Publicacion { nombreUsuario="Johny", caption= "Something Yas", imagenPerfil = "http://placeimg.com/100/100/people/4" , numComent = "1", numKaip = "1", imagenPublicacion="http://placeimg.com/480/280/tech", comments = new List<Comentario>()
            {
                new Comentario {nombreUsuario="Fulano", comentario= "this girl is on FIRE and some more text p aue la vaina se ponga buena pa ve si e dd", imagenUsuario="http://placeimg.com/100/100/people/5"}
            }},
                new Publicacion { nombreUsuario="Maury", caption= "Something Sip", imagenPerfil = "http://placeimg.com/100/100/people/5" , numComent = "2", numKaip = "30", imagenPublicacion="http://placeimg.com/480/280/animals/2", comments = new List<Comentario>()
            {
                new Comentario {nombreUsuario="Fulana", comentario= "this girl is on WATER", imagenUsuario="http://placeimg.com/100/100/people/6"},
                new Comentario {nombreUsuario="Ful", comentario= "this boy is on FIRE", imagenUsuario="http://placeimg.com/100/100/people/5"}
            }
    }

            };
        }
        private void listPictures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var pub = e.SelectedItem as Publicacion;
            Navigation.PushAsync(new DetalleFeed(pub, NavBar));
            //listPictures.SelectedItem = null;
        }

        private void KaipNum_Clicked(object sender, EventArgs e)
        {

        }

        private void CommentNum_Clicked(object sender, EventArgs e)
        {

        }
    }
}