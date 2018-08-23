using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCIC.Views.ViewGeneral
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleEvento : ContentPage
	{
		public DetalleEvento ()
		{
			InitializeComponent ();
		}

        private void MapButton_Clicked(object sender, EventArgs e)
        {
            {
                var map = new Map(
             MapSpan.FromCenterAndRadius(
             new Position(19.443646, -70.684445), Distance.FromMiles(0.3)));

                //{
                //    IsShowingUser = true,
                //    HeightRequest = 100,
                //    WidthRequest = 960,
                //    VerticalOptions = LayoutOptions.FillAndExpand
                //};
                var stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(map);
                Content = stack;

                var position = new Position(19.442354, -70.684648); // Latitude, Longitude
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "Almuerzo en el teatro",
                    Address = "Teatro delante de PA"
                };
                map.Pins.Add(pin);
            };
        }
    }
}