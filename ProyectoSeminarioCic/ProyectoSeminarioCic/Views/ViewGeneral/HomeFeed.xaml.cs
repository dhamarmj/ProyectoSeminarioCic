using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoSeminarioCic.Models;
using System.Collections.ObjectModel;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{

    public partial class HomeFeed : ContentPage
    {
        bool NavBar;
        Services.ApiServices_Comentario apiComm = new Services.ApiServices_Comentario();
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        Services.ApiServices_Publicacion api = new Services.ApiServices_Publicacion();
        ObservableCollection<Post> _listPosts = new ObservableCollection<Post>();
        bool kaip = true;
        string baseUri = "http://proyectosapi.azurewebsites.net";
        public HomeFeed(bool hasNavigationBar)
        {
            NavBar = hasNavigationBar;
            InitializeComponent();
            Title = Proyecto.CurrrentSeminar.Titulo;
            HeaderText.Text = Proyecto.CurrrentSeminar.Titulo;
            HeaderBar.Color = Color.FromHex(Proyecto.CurrrentSeminar.SecondaryColor);
            if (NavBar)
            {
                HeaderBar.IsVisible = HeaderText.IsVisible = HeaderSeparator.IsVisible = false;
                listPictures1.IsVisible = true;
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, NavBar);
                listPictures.IsVisible = true;
            }


        }

        protected override void OnAppearing()
        {
            StartView();
        }

        private async void StartView()
        {
            BtnLoading.IsRunning = true;
            int count = 0;
            var listP = await api.GetPublicacion();
            if (listP.Count > 0)
            {
                foreach (var item in listP)
                {
                    var exists = _listPosts.FirstOrDefault(x => x.Publicacion.Id == item.Id);
                    if (exists == null)
                    {
                        if (item.ImagenPath != string.Empty)
                        {
                            item.ImagenPath = baseUri + item.ImagenPath.Remove(0, 1);
                        }



                        var user = await apiUsuario.GetUsuario(item.Id_usuario);
                        if (user != null)
                        {
                            if (!string.IsNullOrEmpty(user.FotoPath))
                                user.FotoPath = baseUri + user.FotoPath.Remove(0, 1);
                            else
                                user.FotoPath = "baseline_account_circle_black_48.png";

                            var list = await apiComm.GetComentario(Convert.ToDouble(item.Id));
                            if (list != null)
                                count = list.Count;

                            _listPosts.Insert(0, new Post(item, user, count));
                        }
                    }
                    else
                    {
                        if (item.ImagenPath != string.Empty)
                        {
                            item.ImagenPath = baseUri + item.ImagenPath.Remove(0, 1);
                        }

                        var list = await apiComm.GetComentario(Convert.ToDouble(item.Id));
                        if (list != null)
                            count = list.Count;

                        var index = _listPosts.IndexOf(exists);
                        _listPosts[index].Publicacion = item;
                    }
                }
            }

            if (NavBar)
            {
                listPictures1.ItemsSource = _listPosts;
                listPictures1.EndRefresh();
            }
            else
            {
                listPictures.ItemsSource = _listPosts;
                listPictures.EndRefresh();
            }

            BtnLoading.IsRunning = false;
        }

        private void listPictures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var pub = e.SelectedItem as Post;
            Navigation.PushAsync(new DetalleFeed(pub, NavBar));
        }

        private async void KaipNum_Clicked(object sender, EventArgs e)
        {
            var task = (sender as Button).BindingContext as Post;
            await Navigation.PushAsync(new DetalleFeed(task, NavBar, 1));
        }

        private void CommentNum_Clicked(object sender, EventArgs e)
        {

        }

        private void listPictures_Refreshing(object sender, EventArgs e)
        {
            StartView();
        }
    }
}