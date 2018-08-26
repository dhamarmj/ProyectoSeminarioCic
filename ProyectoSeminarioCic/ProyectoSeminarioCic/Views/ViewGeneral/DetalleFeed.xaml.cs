using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    public partial class DetalleFeed : ContentPage
    {
        Post post;
        ObservableCollection<Comment> _comments = new ObservableCollection<Comment>();
        Services.ApiServices_Publicacion apiPubli = new Services.ApiServices_Publicacion();
        Services.ApiServices_Comentario api = new Services.ApiServices_Comentario();
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        string baseUri = "http://proyectosapi.azurewebsites.net";
        bool kaip = true;
        bool Navibar;
        Models.Usuario user;
        public DetalleFeed(Post p, bool NaviBar, int like = 0)
        {
            if (p == null)
                throw new ArgumentNullException();

            InitializeComponent();
            post = p;
            Navibar = NaviBar;
            LoadComments();
            if (NaviBar)
            {
                listComments1.IsVisible = true;
                stack1.IsVisible = true;
                stack1.BindingContext = p;
                listComments1.ItemsSource = _comments;
            }

            else
            {
                listComments.IsVisible = true;
                stack.IsVisible = true;
                stack.BindingContext = p;
                listComments.ItemsSource = _comments;
            }
            if (like > 0)
                KaipM();
        }
        private async void LoadComments()
        {
            var C = await api.GetComentario(Convert.ToDouble(post.Publicacion.Id));
            if (C.Count > 0)
            {
                foreach (var item in C)
                {
                    var exist = _comments.FirstOrDefault(x => x.Comments.Id == item.Id);
                    if (exist == null)
                    {
                        var R = await apiUsuario.GetUsuario(item.Id_usuario);
                        if (R != null)
                        {
                            if (!string.IsNullOrEmpty(R.FotoPath))
                                R.FotoPath = baseUri + R.FotoPath.Remove(0, 1);

                            _comments.Add(new Comment(R, item));
                        }
                    }
                }

                if (Navibar)
                    LblComent1.Text = C.Count.ToString();
                else
                    LblComent.Text = C.Count.ToString();
            }
        }

        private async void KaipM()
        {
            if (kaip)
            {
                post.Publicacion.Kaip = post.Publicacion.Kaip + 1;
                kaip = false;
            }
            else
            {
                post.Publicacion.Kaip = post.Publicacion.Kaip - 1;
                kaip = true;
            }
            post.Publicacion.ImagenPath = "~" + post.Publicacion.ImagenPath.Remove(0, baseUri.Length);

            var R = await apiPubli.ActualizarPublicacion(post.Publicacion);
            if (Navibar)
                LblKaip1.Text = post.Publicacion.Kaip.ToString();
            else
                LblKaip.Text = post.Publicacion.Kaip.ToString();
        }

        private  void KaipNum_Clicked(object sender, EventArgs e)
        {
            KaipM();
        }
       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtComentario.Text))
            {
                var Comment = new Models.Comentario()
                {
                    Id_usuario = Convert.ToInt32(Settings.idUsuario),
                    Texto = TxtComentario.Text,
                    Id_publicacion = post.Publicacion.Id
                };

                var R = await api.RegistrarComentario(Comment);
                if (R)
                {
                    if (user == null)
                        user = await apiUsuario.GetUsuario(Convert.ToInt32(Settings.idUsuario));

                    _comments.Add(new Comment(user, Comment));
                    if (Navibar)
                        LblComent1.Text = _comments.Count.ToString();
                    else
                        LblComent.Text = _comments.Count.ToString();

                    await DisplayAlert("Aviso", "Comentario Enviado!", "Ok");

                    TxtComentario.Text = "";
                }
                else
                    await DisplayAlert("Alerta", "Error de conexion. Intenta nuevamente", "Ok");
            }
            else
                await DisplayAlert("Alerta", "Debes incluir un mensaje!", "Ok");



        }
    }
}