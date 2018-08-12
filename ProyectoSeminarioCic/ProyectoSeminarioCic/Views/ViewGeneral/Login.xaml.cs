using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async private void Btnreg_Clicked1(object sender, EventArgs e)
        {
            var nv = new NavigationPage(new ViewGeneral.Registro2())
            {
                BarBackgroundColor = Color.LightSlateGray
            };
            await Navigation.PushModalAsync(nv);
        }

        async private void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            var validate = await Validate();
            if (validate)
            {
                Services.ApiServices api = new Services.ApiServices();
                var response = await api.LoginUser(Txtnombre.Text, TxtPass.Text);
                if (!response)
                {
                    await DisplayAlert("Alert", "Error, intente nuevamente", "Ok");
                }
                else
                {
                    var r = await api.CheckUsername(Txtnombre.Text, TxtPass.Text);
                    Settings.Rol = r.Rol;
                    if (Settings.Rol == "Charlista" || Settings.Rol == "Participante")
                    {
                        Navigation.InsertPageBefore(new ViewGeneral.Home(Settings.Rol), this);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        Navigation.InsertPageBefore(new ViewAdmin.MainMenu(), this);
                        await Navigation.PopAsync();
                    }
                }
            }
          
        }

        async private Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(Txtnombre.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un usuario", "Aceptar");
                Txtnombre.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtPass.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una Contraseña", "Aceptar");
                TxtPass.Focus();
                return false;
            }

            return true;
        }
    }
}