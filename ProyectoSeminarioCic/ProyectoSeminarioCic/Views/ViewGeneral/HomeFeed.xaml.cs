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
        public HomeFeed()
        {
            InitializeComponent();

          //  List<ComentarioPublicacion> comment1 = new List<ComentarioPublicacion>()
          //  {
          //      new ComentarioPublicacion {nombreUsuario="Fulano", comentario= "this girl is on FIRE"}
          //  };
          //  var comment2 = new List<ComentarioPublicacion>()
          //  {
          //      new ComentarioPublicacion {nombreUsuario="Fulana", comentario= "this girl is on WATER"},
          //      new ComentarioPublicacion {nombreUsuario="Ful", comentario= "this boy is on FIRE"}
          //  };
          //  var comment3 = new List<ComentarioPublicacion>()
          //  {
          //      new ComentarioPublicacion {nombreUsuario="ulano", comentario= "this boy is on WATER"},
          //      new ComentarioPublicacion {nombreUsuario="Fulano", comentario= "this girl is on FIRE"},
          //      new ComentarioPublicacion {nombreUsuario="Fulana", comentario= "this girl is on WATER"}

          //  };
          //  var publicaciones = new List<PubliacionModel>
          //  {
          //      new PubliacionModel { nombreUsuario="Mosh", caption= "Something Deep",  imagenPerfil = "http://placeimg.com/100/100/people/1" , numComent = "1", numKaip = "15", imagenPublicacion="http://placeimg.com/480/280/animals/1", comentarioModel = comment1 },
          //      new PubliacionModel { nombreUsuario="Josh", caption= "Something Meaningfull", imagenPerfil = "http://placeimg.com/100/100/people/2" , numComent = "2", numKaip = "20", imagenPublicacion="http://placeimg.com/480/280/arch", comentarioModel = comment2 },
          //      new PubliacionModel { nombreUsuario="Molly", caption= "Something Else", imagenPerfil = "http://placeimg.com/100/100/people/3" , numComent = "3", numKaip = "5", imagenPublicacion="http://placeimg.com/480/280/nature", comentarioModel = comment3 },
          //      new PubliacionModel { nombreUsuario="Johny", caption= "Something Yas", imagenPerfil = "http://placeimg.com/100/100/people/4" , numComent = "1", numKaip = "1", imagenPublicacion="http://placeimg.com/480/280/tech", comentarioModel = comment1 },
          //      new PubliacionModel { nombreUsuario="Maury", caption= "Something Sip", imagenPerfil = "http://placeimg.com/100/100/people/5" , numComent = "2", numKaip = "30", imagenPublicacion="http://placeimg.com/480/280/animals/2", comentarioModel = comment2 }

          //  };

          //listPictures.ItemsSource = publicaciones;
        }

        private void listPictures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listPictures.SelectedItem = null;
        }

         private void ButtonHome_Clicked(object sender, EventArgs e)
        {
           //await Navigation.PushModalAsync(new HomeCharlistas());
        }

        async private void ButtonNotifications_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeNotificaciones());
        }

        private void ButtonPost_Clicked(object sender, EventArgs e)
        {

        }

      async  private void ButtonSchedule_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ViewCharlista.HorarioCharlistas());
        }

        async private void ButtonConfiguration_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new ViewUsuario.VistaPerfil());
        }

        private void KaipNum_Clicked(object sender, EventArgs e)
        {

        }

        private void CommentNum_Clicked(object sender, EventArgs e)
        {

        }
    }
}