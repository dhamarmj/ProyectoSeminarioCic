using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeminarioHome : ContentPage
    {
        public SeminarioHome()
        {
            InitializeComponent();
            _seminario = new ObservableCollection<Models.Seminario>
            {
                new Models.Seminario{ Titulo= "Somehting", Descripcion= "Algo muy largo va aqiofds fjslkjf fsdjfklas fjsdlk fjdslmf f d fd w  asd fds", Anio=new DateTime(2014,06,14) , icon = "http://placeimg.com/100/100/nature/1" },
                new Models.Seminario{ Titulo= "Somehting 2", Descripcion= "Algo muy largo va aqiofds fjslkjf fsdjfklas fjsdlk fjdslmf f d fd w  asd fds", Anio=new DateTime(2015,06,14) , icon = "http://placeimg.com/100/100/nature/2" },
                new Models.Seminario{ Titulo= "Somehting 3", Descripcion= "Algo muy largo va aqiofds fjslkjf fsdjfklas fjsdlk fjdslmf f d fd w  asd fds", Anio=new DateTime(2016,06,14) , icon = "http://placeimg.com/100/100/nature/" }
            };
            ListSeminar.ItemsSource = _seminario;

        }

        public ObservableCollection<Models.Seminario> _seminario;

        async private void Eliminar_Clicked(object sender, EventArgs e)
        {
            //VALIDAR SI SE PUEDE BORRAR <SI NO TIENE NINGUN EVENTO>

            var res = await DisplayAlert("Aviso", "Está a punto de eliminar un Seminario, ¿Está seguro?", "Sí", "No");
            if (res)
            {
                var sem = (sender as MenuItem).CommandParameter as Models.Seminario;
                _seminario.Remove(sem);
                await DisplayAlert("Éxito", "Registro eliminado", "Aceptar");
            }
        }

        private void Editar_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var Seminario = item.CommandParameter as Models.Seminario;
            CUSEminarioStart(Seminario);
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            CUSEminarioStart(new Models.Seminario());
        }

        async private void CUSEminarioStart(Models.Seminario SE)
        {
            await Navigation.PushAsync(new CU_Seminario(SE));
        }
    }
}