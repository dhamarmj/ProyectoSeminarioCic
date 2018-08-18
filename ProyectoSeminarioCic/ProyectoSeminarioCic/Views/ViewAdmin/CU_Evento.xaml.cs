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
        Services.ApiServices_Usuario apiUsuario = new Services.ApiServices_Usuario();
        CharlistasList newForm = new CharlistasList();

        int idCharlista = -1;
        string opcion;
        public CU_Evento(Models.Evento eve)
        {
            InitializeComponent();
            _Evento = eve;
            this.BindingContext = _Evento;
            loadCharlistaName();
            if (_Evento == null)
            {
                LblDescrip.IsVisible = false;
                TxtDescripcion.Text = "Descripción del evento";
                LblCharlista.Text = "Seleccionar Charlista";
            }
            else
            {
                if (eve.Id_Charlista != -1)
                {
                    GridChalistas.IsVisible = true;
                    loadcharlista();
                }

                else
                    GridChalistas.IsVisible = false;
            }
        }

        private async void loadcharlista()
        {
            var cha = await apiUsuario.GetUsuario(Convert.ToInt32(_Evento.Id_Charlista));
            LblCharlista.Text = cha.Nombre + " " + cha.Apellido;
        }
        protected override void OnAppearing()
        {
            BtnLoading.IsRunning = true;
                loadCharlistaName();
            BtnLoading.IsRunning = false;
        }
        private void loadCharlistaName()
        {
            LblCharlista.Text = newForm.NameCharlista;
            idCharlista = newForm.idCharlista;
        }

        private bool Validate()
        {
            if (TxtTitulo.Text != string.Empty & btnfecha.Date != null & btnhora.Time != null)
                return true;
            else
            {
                DisplayAlert("Aviso", "Debe digitar un Título, Fecha y Hora para salvar el evento", "Ok");
                return false;
            }
        }

        private async void SaveEvento()
        {
            var time = DateTime.Today.Add(btnhora.Time);
            var _evento = new Models.Evento
            {
                Titulo = TxtTitulo.Text,
                Fecha = new DateTime(btnfecha.Date.Year, btnfecha.Date.Month, btnfecha.Date.Day, time.Hour, time.Minute, time.Second),
                Duracion = Convert.ToInt32(btnduracion.Text),
                Descripcion = TxtDescripcion.Text,
                Ubicacion = TxtUbicacion.Text,
                Id_seminario = Convert.ToInt32(Settings.idSeminario)
            };
            if (idCharlista > -1)
                _evento.Id_Charlista = idCharlista;

            _evento.SetFechaFin();

            var response = await apiEvento.RegistrarEvento(_evento);
            if (response)
            {
                await DisplayAlert("Aviso", "Evento Salvado exitosamente", "Ok");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
        }


        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (_Evento == null) //Es uno nuevo que tu vas a salvar?
            {
                if (Validate())
                {
                    var checkTitulo = await apiEvento.GetEvento(TxtTitulo.Text);
                    if (checkTitulo != null)
                        await DisplayAlert("Aviso", "No pueden haber 2 Eventos con el mismo Título", "Ok");
                    else
                    {
                        SaveEvento();
                    }
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(newForm);
        }
    }
}