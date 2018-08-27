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
	public partial class Encuesta : ContentPage
	{
        static int preg1=0, preg2=0, preg3=0, preg4=0, preg5=0, preg6=0;
        Models.Evento_Usuario _Eveu;
        Services.ApiServices_Evaluacion api = new Services.ApiServices_Evaluacion();
		public Encuesta (Models.Evento_Usuario R, string Titulo)
		{
			InitializeComponent ();
            Title = "Evalua esta charla!";
            _Eveu = R;
            LblCharla.Text = Titulo;
            btnEnviar.Clicked += BtnEnviar_Clicked;
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            if (preg1 > 0 && preg2 > 0 && preg3 > 0 && preg4 >0 && preg5 >0 && preg6 >0)
            {
                var Eval = new Models.Evaluacion()
                {
                    Id_Evento_Participante =_Eveu.Id,
                    Value1 = preg1,
                    Value2 = preg2,
                    Value3 = preg3,
                    Value4 = preg4,
                    Value5 = preg5,
                    Value6 = preg6
                };

                var R = await api.RegistrarEvaluacion(Eval);
                if (R)
                {
                    await DisplayAlert("Aviso", "Evaluacion enviada correctamente", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Alerta", "Error de conexión. Intenta nuevamente", "Ok");
            }
            else
                await DisplayAlert("Alerta", "Debes evaluar todos los puntos!", "Ok");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            star1.Source = "estrellasel";
            star2.Source = "estrellita";
            star3.Source = "estrellita";
            star4.Source = "estrellita";
            star5.Source = "estrellita";
            preg1 = 1;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            star1.Source = "estrellasel";
            star2.Source = "estrellasel";
            star3.Source = "estrellita";
            star4.Source = "estrellita";
            star5.Source = "estrellita";
            preg1 = 2;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            star1.Source = "estrellasel";
            star2.Source = "estrellasel";
            star3.Source = "estrellasel";
            star4.Source = "estrellita";
            star5.Source = "estrellita";
            preg1 = 3;
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            star1.Source = "estrellasel";
            star2.Source = "estrellasel";
            star3.Source = "estrellasel";
            star4.Source = "estrellasel";
            star5.Source = "estrellita";
            preg1 = 4;
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            star1.Source = "estrellasel";
            star2.Source = "estrellasel";
            star3.Source = "estrellasel";
            star4.Source = "estrellasel";
            star5.Source = "estrellasel";
            preg1 = 5;
        }
        
        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            star21.Source = "estrellasel";
            star22.Source = "estrellita";
            star23.Source = "estrellita";
            star24.Source = "estrellita";
            star25.Source = "estrellita";
            preg2 = 1;
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            star21.Source = "estrellasel";
            star22.Source = "estrellasel";
            star23.Source = "estrellita";
            star24.Source = "estrellita";
            star25.Source = "estrellita";
            preg2 = 2;
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            star21.Source = "estrellasel";
            star22.Source = "estrellasel";
            star23.Source = "estrellasel";
            star24.Source = "estrellita";
            star25.Source = "estrellita";
            preg2 = 3;
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            star21.Source = "estrellasel";
            star22.Source = "estrellasel";
            star23.Source = "estrellasel";
            star24.Source = "estrellasel";
            star25.Source = "estrellita";
            preg2 = 4;
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            star21.Source = "estrellasel";
            star22.Source = "estrellasel";
            star23.Source = "estrellasel";
            star24.Source = "estrellasel";
            star25.Source = "estrellasel";
            preg2 = 5;
        }

       
        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            star31.Source = "estrellasel";
            star32.Source = "estrellita";
            star33.Source = "estrellita";
            star34.Source = "estrellita";
            star35.Source = "estrellita";
            preg3 = 1;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            star31.Source = "estrellasel";
            star32.Source = "estrellasel";
            star33.Source = "estrellita";
            star34.Source = "estrellita";
            star35.Source = "estrellita";
            preg3 = 2;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            star31.Source = "estrellasel";
            star32.Source = "estrellasel";
            star33.Source = "estrellasel";
            star34.Source = "estrellita";
            star35.Source = "estrellita";
            preg3 = 3;
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            star31.Source = "estrellasel";
            star32.Source = "estrellasel";
            star33.Source = "estrellasel";
            star34.Source = "estrellasel";
            star35.Source = "estrellita";
            preg3 = 4;
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
            star31.Source = "estrellasel";
            star32.Source = "estrellasel";
            star33.Source = "estrellasel";
            star34.Source = "estrellasel";
            star35.Source = "estrellasel";
            preg3 = 5;
        }

        
        private void TapGestureRecognizer_Tapped_15(object sender, EventArgs e)
        {
            star41.Source = "estrellasel";
            star42.Source = "estrellita";
            star43.Source = "estrellita";
            star44.Source = "estrellita";
            star45.Source = "estrellita";
            preg4 = 1;
        }

        private void TapGestureRecognizer_Tapped_16(object sender, EventArgs e)
        {
            star41.Source = "estrellasel";
            star42.Source = "estrellasel";
            star43.Source = "estrellita";
            star44.Source = "estrellita";
            star45.Source = "estrellita";
            preg4 = 2;
        }

        private void TapGestureRecognizer_Tapped_17(object sender, EventArgs e)
        {
            star41.Source = "estrellasel";
            star42.Source = "estrellasel";
            star43.Source = "estrellasel";
            star44.Source = "estrellita";
            star45.Source = "estrellita";
            preg4 = 3;
        }

        private void TapGestureRecognizer_Tapped_18(object sender, EventArgs e)
        {
            star41.Source = "estrellasel";
            star42.Source = "estrellasel";
            star43.Source = "estrellasel";
            star44.Source = "estrellasel";
            star45.Source = "estrellita";
            preg4 = 4;
        }

        private void TapGestureRecognizer_Tapped_19(object sender, EventArgs e)
        {
            star41.Source = "estrellasel";
            star42.Source = "estrellasel";
            star43.Source = "estrellasel";
            star44.Source = "estrellasel";
            star45.Source = "estrellasel";
            preg4 = 5;
        }

        private void TapGestureRecognizer_Tapped_20(object sender, EventArgs e)
       {
            star51.Source = "estrellasel";
            star52.Source = "estrellita";
            star53.Source = "estrellita";
            star54.Source = "estrellita";
            star55.Source = "estrellita";
            preg5 = 1;
        }

        private void TapGestureRecognizer_Tapped_21(object sender, EventArgs e)
        {
            star51.Source = "estrellasel";
            star52.Source = "estrellasel";
            star53.Source = "estrellita";
            star54.Source = "estrellita";
            star55.Source = "estrellita";
            preg5 = 2;
        }

        private void TapGestureRecognizer_Tapped_22(object sender, EventArgs e)
        {
            star51.Source = "estrellasel";
            star52.Source = "estrellasel";
            star53.Source = "estrellasel";
            star54.Source = "estrellita";
            star55.Source = "estrellita";
            preg5 = 3;
        }

        private void TapGestureRecognizer_Tapped_23(object sender, EventArgs e)
        {
            star51.Source = "estrellasel";
            star52.Source = "estrellasel";
            star53.Source = "estrellasel";
            star54.Source = "estrellasel";
            star55.Source = "estrellita";
            preg5 = 4;
        }

        private void TapGestureRecognizer_Tapped_24(object sender, EventArgs e)
        {
            star51.Source = "estrellasel";
            star52.Source = "estrellasel";
            star53.Source = "estrellasel";
            star54.Source = "estrellasel";
            star55.Source = "estrellasel";
            preg5 = 5;
        }

        private void TapGestureRecognizer_Tapped_25(object sender, EventArgs e)
        {
            star61.Source = "estrellasel";
            star62.Source = "estrellita";
            star63.Source = "estrellita";
            star64.Source = "estrellita";
            star65.Source = "estrellita";
            preg6 = 1;
        }

        private void TapGestureRecognizer_Tapped_26(object sender, EventArgs e)
        {
            star61.Source = "estrellasel";
            star62.Source = "estrellasel";
            star63.Source = "estrellita";
            star64.Source = "estrellita";
            star65.Source = "estrellita";
            preg6 = 2;
        }

        private void TapGestureRecognizer_Tapped_27(object sender, EventArgs e)
        {
            star61.Source = "estrellasel";
            star62.Source = "estrellasel";
            star63.Source = "estrellasel";
            star64.Source = "estrellita";
            star65.Source = "estrellita";
            preg6 = 3;
        }

        private void TapGestureRecognizer_Tapped_28(object sender, EventArgs e)
        {
            star61.Source = "estrellasel";
            star62.Source = "estrellasel";
            star63.Source = "estrellasel";
            star64.Source = "estrellasel";
            star65.Source = "estrellita";
            preg6 = 4;
        }

        private void TapGestureRecognizer_Tapped_29(object sender, EventArgs e)
        {
            star61.Source = "estrellasel";
            star62.Source = "estrellasel";
            star63.Source = "estrellasel";
            star64.Source = "estrellasel";
            star65.Source = "estrellasel";
            preg6 = 5;
        }
    }
}