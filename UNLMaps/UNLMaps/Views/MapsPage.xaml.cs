using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Gms.Maps;
using UNLMaps.Views.CustomLayouts;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace UNLMaps.Views
{
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
           // map.HasZoomEnabled = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Position position = new Position();
            var geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();
            var positions = await geocoder.GetPositionsForAddressAsync("Minsk");
            if (positions.Count() > 0)
            {
                var pos = positions.First();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(2)));
                var reg = map.VisibleRegion;
                var format = "0.00";
                position = pos;
            }
            else
            {
                await this.DisplayAlert("Not found", "Geocoder returns no results", "Close");
            }
            await Task.Delay(1000); // workaround for #30 [Android]Map.Pins.Add doesn't work when page OnAppearing

            var pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Tokyo SKYTREE",
                Address = "Sumida-ku, Tokyo, Japan",
                Position = position,
                Icon = BitmapDescriptorFactory.FromView(new BindingPinView("A"))
            };
            map.Pins.Add(pin);
         }

    }
}
