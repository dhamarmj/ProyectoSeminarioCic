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
        //inicializar la clase para buscar en la nube
        Services.ApiServices_Seminario api = new Services.ApiServices_Seminario();
        public SeminarioHome()
        {
            InitializeComponent();
            ListSeminar.ItemsSource = _seminario;
        }

        //en esta clase se realizan las busquedas y se actualiza la lista de seminarios
        public async void LoadSeminars()
        {
            var list = await api.GetSeminarios();
            _seminario = new ObservableCollection<Models.Seminario>(list);
            ListSeminar.ItemsSource = _seminario;
            ListSeminar.EndRefresh();
        }

        public ObservableCollection<Models.Seminario> _seminario;

        //Eliminando un seminario
        async private void Eliminar_Clicked(object sender, EventArgs e)
        {
            var sem = (sender as MenuItem).CommandParameter as Models.Seminario;
            //Validacion
           if(sem.Boleta != null || sem.Charla != null || sem.Evento != null)
            {
                await DisplayAlert("Aviso", "Este Seminario tiene eventos registrados y no se puede eliminar","Ok");
            }
           else
            {
                var res = await DisplayAlert("Aviso", "Está a punto de eliminar un Seminario, ¿Está seguro?", "Sí", "No");
                if (res)
                {
                   
                    //Lo quito de la lista en la nube
                    var response = await api.EliminarSeminario(sem.Id);
                    if (response.IsSuccessStatusCode)
                    {
                        //Lo quito de la lista local si no hay errores
                        _seminario.Remove(sem);
                        await DisplayAlert("Aviso", "Seminario eliminado exitosamente", "Ok");
                    }
                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
                }
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
            CUSEminarioStart(null);
        }

        async private void CUSEminarioStart(Models.Seminario SE)
        {
            await Navigation.PushAsync(new CU_Seminario(SE));
        }

        private void ListSeminar_Refreshing(object sender, EventArgs e)
        {
            LoadSeminars();
        }
    }
}