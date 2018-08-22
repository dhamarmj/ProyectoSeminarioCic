using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewAdmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CU_Seminario : ContentPage
    {
        private Models.Seminario _seminario;
        //La clase donde estan los metodos para entrar a la nube
        Services.ApiServices_Seminario api = new Services.ApiServices_Seminario();
        public CU_Seminario(Models.Seminario se)
        {
            _seminario = se;
            InitializeComponent();
            DtpInicio.Date = DateTime.Now;
            this.BindingContext = _seminario;
            if (_seminario == null)
                EntDescripcion.Text = "Descripción del Seminario";
        }

        private void AddLogo_Clicked(object sender, EventArgs e)
        {

        }

        private bool Validar()
        {
            if (EntTitulo.Text == null && DtpInicio.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                DisplayAlert("Aviso", "Debe seleccionar un Título y Fecha para poder salvar este seminario", "Ok");
                return false;
            }

            return true;
        }

        private async Task Salvar_Clicked(object sender, EventArgs e)
        {
            //el btnloading es una opcion de "cargando" por si dura mucho HAY QUE PONERLO EN LA VISTA! 
            BtnLoading.IsRunning = true;
            if (Validar())
            {
                if (_seminario == null) //Es uno nuevo que tu vas a salvar?
                {
                    _seminario = new Models.Seminario
                    {
                        Anio = DtpInicio.Date,
                        Descripcion = EntDescripcion.Text,
                        Titulo = EntTitulo.Text
                    };
                    //Salvar
                    //insertar = Post
                    var response = await api.RegistrarSeminario(_seminario);
                    if (response)
                    {
                        await DisplayAlert("Aviso", "Seminario Salvado exitosamente", "Ok");
                        await Navigation.PopAsync();
                    }

                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");

                }
                else //si no es uno nuevo es que Vas a actualizar
                {
                    //Actualizar = Put 
                    var response = await api.ActualizarSeminario(_seminario);
                    if (response)
                    {
                        await DisplayAlert("Aviso", "Seminario actualizado exitosamente", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
                }
                //Quito el boton de cargar 
            }
            BtnLoading.IsRunning = false;
        }

    }
}