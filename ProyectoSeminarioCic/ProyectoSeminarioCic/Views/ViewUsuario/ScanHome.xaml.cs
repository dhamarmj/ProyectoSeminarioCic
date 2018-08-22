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
                BtnLoading.IsRunning = false;
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<ICodeScanningService>();
            var result = await scanner.ScanAsync();
            if (result != null)
                Settings.idBoleta = result;

            loadBoleta();
        }
    }
}