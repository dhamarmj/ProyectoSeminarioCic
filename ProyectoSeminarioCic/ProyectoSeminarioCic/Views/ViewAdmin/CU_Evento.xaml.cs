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
    public partial class CU_Evento : ContentPage
    {
        private Models.Evento _Evento;

        Services.ApiServices_Eventos apiEvento = new Services.ApiServices_Eventos();
        Services.ApiServices_Charlas apiCharla = new Services.ApiServices_Charlas();
        public CU_Evento(Models.Evento eve)
        {
            _Evento = eve;
            InitializeComponent();
            Init();
            if (_Evento.Titulo == null)
                LblDescrip.IsVisible = false;
            this.BindingContext = _Evento;
        }

        List<charlistas> charlistas;
        private void Init()
        {
            charlistas = new List<charlistas>()
            {
                new charlistas { nombre = "Alberto", apellido = "Castro" },
                new charlistas { nombre = "Flor", apellido = "Martinez" },
                new charlistas { nombre = "Gilberto", apellido = "Rosa" },
                new charlistas { nombre = "Amanda", apellido = "Jimenza" },
                new charlistas { nombre = "Karol", apellido = "Peralta" },
                new charlistas { nombre = "Antonio", apellido = "Ortega" },
                new charlistas { nombre = "Casemiro", apellido = "Vidal" },
                new charlistas { nombre = "Pedro", apellido = "Olivas" }
            };
            pickerbtn.ItemsSource = charlistas;

        }
        private void pickerbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex > -1)
            {
                picker.SelectedItem.ToString();
            }
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (_Evento == null) //Es uno nuevo que tu vas a salvar?
            {
                if(pickerbtn.SelectedIndex > -1)
                {
                    var _charla = new Models.Charla
                    {
                        Titulo = TxtTitulo.Text,
                        Fecha = btnfecha.Date,
                        Duracion = btnduracion.Text,
                        TSHora = btnhora.Time,
                        Descripcion = TxtDescripcion.Text,
                        Id_Charlista = 1,
                        Ubicacion = TxtUbicacion.Text,
                    };
                    var response = await apiCharla.RegistrarCharla(_charla);
                    if (response)
                    {
                        await DisplayAlert("Aviso", "Charla Salvada exitosamente", "Ok");
                        await Navigation.PopAsync();
                    }

                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
                }
                else
                {
                    var _evento = new Models.Evento
                    {
                        Titulo = TxtTitulo.Text,
                        Fecha = btnfecha.Date,
                        Duracion = btnduracion.Text,
                        TSHora = btnhora.Time,
                        Descripcion = TxtDescripcion.Text,
                        Ubicacion = TxtUbicacion.Text,
                    };
                    var response = await apiEvento.RegistrarEvento(_evento);
                    if (response)
                    {
                        await DisplayAlert("Aviso", "Evento Salvado exitosamente", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                        await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
                }
              
            }
            else //si no es uno nuevo es que Vas a actualizar
            {
                //Actualizar = Put 
                var response = await apiEvento.ActualizarEvento(_Evento);
                if (response)
                {
                    await DisplayAlert("Aviso", "Evento actualizado exitosamente", "Ok");
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
            }
            //Quito el boton de cargar 
            BtnLoading.IsRunning = false;
        }
    }
}