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
        List<CharlistasList.Charlistas> _charlistas = new List<CharlistasList.Charlistas>();
        List<int> idCharlista = new List<int>();
        string opcion;
        public CU_Evento(Models.Evento eve)
        {
            InitializeComponent();
            _Evento = eve;
            this.BindingContext = _Evento;
            if (eve == null)
            {
                TxtDescripcion.Text = "Texto con la descripción del evento";
                btnfecha.Date = DateTime.Now;
            }
        }
        protected override void OnAppearing()
        {
            BtnLoading.IsRunning = true;
            loadCharlistaName();
            BtnLoading.IsRunning = false;
        }
        private async void loadCharlistaName()
        {
            if (_Evento == null)
            {
                LblCharlista.Text = newForm.returnCharlistas();
                idCharlista = newForm.idCharlista;
            }
            else
            {
                if (String.IsNullOrEmpty(LblCharlista.Text))
                {
                    var chalist = await apiUsuario.GetUsuario(_Evento.Id, 0);
                    if (chalist.Count > 0)
                    {
                        foreach (var item in chalist)
                        {
                            _charlistas.Add(new CharlistasList.Charlistas(item));
                            LblCharlista.Text += item.Nombre + " " + item.Apellido + ", ";
                        }

                        LblCharlista.Text = LblCharlista.Text.Remove(LblCharlista.Text.Length - 2);
                        newForm._charlistasConfirmados = _charlistas;
                    }
                    else
                    {
                        LblCharlista.IsVisible = false;
                        BtnSearch.IsVisible = false;
                        LblLe.IsVisible = false;
                    }
                }
                else
                {
                    LblCharlista.Text = newForm.returnCharlistas();
                    idCharlista = newForm.idCharlista;
                }
            }
        }
        private bool Validate()
        {
            if (!string.IsNullOrEmpty(TxtTitulo.Text)  && btnfecha.Date != DateTime.Now && btnhora.Time != null)
            {
                int result;
                if (!int.TryParse(btnduracion.Text, out result))
                {
                    return false;
                }
            }
            else
            {
                DisplayAlert("Aviso", "Debe digitar un Título, Fecha y Hora para salvar el evento", "Ok");
                return false;
            }
            return true;
        }
        private async void ActualizarUsuarios(int ide)
        {
            foreach (int item in idCharlista)
            {
                var V = await apiUsuario.GetUsuario(item);
                if (V != null)
                {
                    V.Id_evento = ide;
                    var R = await apiUsuario.ActualizarUsuario(V);
                }
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

            _evento.SetFechaFin();
            var response = await apiEvento.RegistrarEvento(_evento);
            if (response)
            {
                var id = await apiEvento.GetEvento(_evento.Titulo, Settings.idSeminario);
                if (id != null)
                {
                    ActualizarUsuarios(id.Id);

                    await DisplayAlert("Aviso", "Evento Salvado exitosamente", "Ok");
                    await Navigation.PopAsync();
                }

            }
            else
                await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
        }
      



        private async void EditarUsuarios(int idE)
        {
            if(_charlistas.Count > 0)
            {
                foreach (var item in _charlistas)
                {
                    var Us = await apiUsuario.GetUsuario(item.User.Id);
                    if(Us != null)
                    {
                        Us.Id_evento = 0;
                        var R = await apiUsuario.ActualizarUsuario(Us);
                    }
                }
            }
            if(idCharlista.Count > 0)
            {
                foreach (var item in idCharlista)
                {
                    var Us = await apiUsuario.GetUsuario(item);
                    if (Us != null)
                    {
                        Us.Id_evento = idE;
                        var R = await apiUsuario.ActualizarUsuario(Us);
                    }
                }
            }
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            BtnLoading.IsRunning = true;
            if (_Evento == null) //Es uno nuevo que tu vas a salvar?
            {
                if (Validate())
                {
                    var checkTitulo = await apiEvento.GetEvento(TxtTitulo.Text, Settings.idSeminario);
                    if (checkTitulo != null)
                        await DisplayAlert("Aviso", "No pueden haber 2 Eventos con el mismo Título", "Ok");
                    else
                    {
                        SaveEvento();

                        newForm.NameCharlista = new List<string>();
                        newForm.idCharlista = new List<int>();
                    }
                }
            }
            else //si no es uno nuevo es que Vas a actualizar
            {
                var time = DateTime.Today.Add(btnhora.Time);
                _Evento.Titulo = TxtTitulo.Text;
                _Evento.Fecha = new DateTime(btnfecha.Date.Year, btnfecha.Date.Month, btnfecha.Date.Day, time.Hour, time.Minute, time.Second);
                _Evento.Duracion = Convert.ToInt32(btnduracion.Text);
                _Evento.Descripcion = TxtDescripcion.Text;
                _Evento.Ubicacion = TxtUbicacion.Text;
                _Evento.SetFechaFin();
                //Actualizar = Put 
                var response = await apiEvento.ActualizarEvento(_Evento);
                if (response)
                {
                    EditarUsuarios(_Evento.Id);

                    await DisplayAlert("Aviso", "Evento actualizado exitosamente", "Ok");
                    await Navigation.PopAsync();

                    newForm.NameCharlista = new List<string>();
                    newForm.idCharlista = new List<int>();
                    _charlistas = new List<CharlistasList.Charlistas>();
                }
                else
                    await DisplayAlert("Error", "Existe un error en la conexión", "Ok");
            }
            //Quito el boton de cargar 
            BtnLoading.IsRunning = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            newForm.Titulo = TxtTitulo.Text;
            await Navigation.PushAsync(newForm);
        }
    }
}