using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro1 : ContentPage
    {
        public IEnumerable<RadioItem> RadioGroupSource { get; }
            = new List<RadioItem>() {
                new RadioItem() {ID = 0, Name = "Masculino" },
                new RadioItem() {ID = 1, Name= "Femenino" },
            };

        public Registro1()
        {
            InitializeComponent();
            btnsiguiente.Clicked += Btnsiguiente_Clicked;

            this.BindingContext = this;
        }
        public class RadioItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        async private void Btnsiguiente_Clicked(object sender, EventArgs e)
        {
            //var usuario = new Models.Usuario
            //{
            //    Nombre = entrynom.Text, Apellido = entryapellido.Text, Fecha_Nacimiento = btnfecha.Date
            //};

            await Navigation.PushAsync(new Registro2(new Models.Usuario()));
        }
    }
}