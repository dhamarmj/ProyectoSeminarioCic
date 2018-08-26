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
    public partial class GenerarClave : ContentPage
    {
        Services.ApiServices_CurrentSem api = new Services.ApiServices_CurrentSem();
        public GenerarClave()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            BtnLoading.IsRunning = true;
            loadClave();
            BtnLoading.IsRunning = false;
        }

        private async void loadClave()
        {
            var Ms = await api.GetMainSeminario(1);
            if(Ms != null)
            {
                if (string.IsNullOrEmpty(Ms.ClaveCharlistas))
                {
                    Generar();
                    Ms.ClaveCharlistas = ClaveResultado.Text;
                    var R = await api.ActualizarMainSeminario(Ms);
                }
                else
                {
                    ClaveResultado.Text = Ms.ClaveCharlistas;
                }
            }
        }

        private void Generar()
        {
            var charsALL = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@$%.,";
            var randomIns = new Random();
            int N = 10;
            var rndChars = Enumerable.Range(0, N)
                            .Select(_ => charsALL[randomIns.Next(charsALL.Length)])
                            .ToArray();
            rndChars[randomIns.Next(rndChars.Length)] = "0123456789"[randomIns.Next(10)];

            var randomstr = new String(rndChars);
            ClaveResultado.Text = randomstr;
        }
    }
}