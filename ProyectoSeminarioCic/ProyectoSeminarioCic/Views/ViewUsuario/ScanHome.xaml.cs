using ProyectoSeminarioCic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanHome : ContentPage
    {
        Services.ApiServices_Boletas api = new ApiServices_Boletas();
        public ScanHome()
        {
            InitializeComponent();
            Title = "";
           
        }

        private async void loadBoleta()
        {
            BtnLoading.IsRunning = true;
            if (!string.IsNullOrEmpty(Settings.idBoleta))
            {
                var boleta = new Models.Boleta()
                {
                    Id_seminario = Convert.ToInt32(Settings.idSeminario),
                    Id_usuario = Convert.ToInt32(Settings.idUsuario),
                    Numero_serie = Settings.idBoleta
                };

                var resp = await api.RegistrarBoleta(boleta);
                if (resp)
                {
                    BtnLoading.IsRunning = false;
                    Navigation.InsertPageBefore(new ViewGeneral.Home(), this);
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Aviso", "Error de conexión", "Ok");
            }
            else
                await DisplayAlert("Aviso", "Error al detectar código de barras. Intente nuevamente", "Ok");
            BtnLoading.IsRunning = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string value = string.Empty;
            var scanner = DependencyService.Get<ICodeScanningService>();
            var result = await scanner.ScanAsync();
            if (result != null)
               value = result.ToString();

            Settings.idBoleta = value;
            loadBoleta();
        }

        private async void Btnvolver_Clicked(object sender, EventArgs e)
        {
            var nv = (new ViewGeneral.Login());
            Navigation.InsertPageBefore(nv, this);
            await Navigation.PopAsync();
        }
    }
}