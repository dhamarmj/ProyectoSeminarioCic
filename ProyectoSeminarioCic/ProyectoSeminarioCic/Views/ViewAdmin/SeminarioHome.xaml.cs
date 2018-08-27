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
        Services.ApiServices_Eventos apiEventos = new Services.ApiServices_Eventos();
        Services.ApiServices_Boletas apiBoletas = new Services.ApiServices_Boletas();
        Services.ApiServices_Seminario api = new Services.ApiServices_Seminario();
        Services.ApiServices_CurrentSem apiActual = new Services.ApiServices_CurrentSem();
        ObservableCollection<Models.Seminario> _seminario;
        public SeminarioHome()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
         //   LoadSeminars();
            LoadCurrentSeminar();
        }

        //en esta clase se realizan las busquedas y se actualiza la lista de seminarios
        public async void LoadSeminars()
        {
            var list = await api.GetSeminarios();
            if (list != null)
            {
                _seminario = new ObservableCollection<Models.Seminario>(list);
                ListSeminar.ItemsSource = _seminario;
                ListSeminar.EndRefresh();
            }
        }

        public async void LoadCurrentSeminar()
        {
            if (!string.IsNullOrEmpty(Settings.idSeminario))
            {
                var value = await api.GetSeminario(Convert.ToInt32(Settings.idSeminario));
                if (value != null)
                    LblCurrentSeminario.Text = value.Titulo.ToString();
            }
            
        }

        //Eliminando un seminario
        async private void Eliminar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            var sem = (sender as MenuItem).CommandParameter as Models.Seminario;
            var valuesEvento = await apiEventos.GetEventos(Convert.ToInt32(sem.Id));
            var valuesBoleta = await apiBoletas.GetBoleta(Convert.ToInt32(sem.Id));
            //Validacion
            if (valuesEvento.Count > 0 || valuesBoleta.Count > 0)
            {
                await DisplayAlert("Aviso", "Este Seminario tiene eventos registrados y no se puede eliminar", "Ok");
            }
            else
            {
                var res = await DisplayAlert("Aviso", "Está a punto de eliminar un Seminario, ¿Está seguro?", "Sí", "No");
                if (res)
                {

                    //Lo quito de la lista en la nube
                    var response = await api.EliminarSeminario(sem.Id);
                    if (response)
                    {
                        if (sem.Id == Convert.ToInt32(Settings.idSeminario))
                        {
                            Settings.idSeminario = "0";
                            LblCurrentSeminario.Text = "Selecciona el Seminario Actual";
                        }

                        //Lo quito de la lista local si no hay errores
                        _seminario.Remove(sem);
                        await DisplayAlert("Aviso", "Seminario eliminado exitosamente", "Ok");
                    }
                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");


                }
            }
            BtnLoading.IsRunning = false;
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

        private async void Actual_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var Seminario = item.CommandParameter as Models.Seminario;
            LblCurrentSeminario.Text = Seminario.Titulo;
            Settings.idSeminario = Seminario.Id.ToString();
            var M = await apiActual.GetMainSeminario(Settings.idSeminario);
            if (M != null)
            {
                var R = await apiActual.ActualizarMainSeminario(M);
                if (R)
                    await DisplayAlert("Aviso", "Seminario Actual refrescado", "Ok");
                else
                    await DisplayAlert("Aviso", "Error de conexión", "Ok");
            }
            else
                await DisplayAlert("Aviso", "Error de conexión", "Ok");
        }
    }



}