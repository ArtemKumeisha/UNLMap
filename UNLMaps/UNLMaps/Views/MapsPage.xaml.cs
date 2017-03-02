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
            Position position = new Position(23.68, -46.87);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(2)));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
//            var geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();
//            var positions = await geocoder.GetPositionsForAddressAsync("Minsk");
//            if (positions.Count() > 0)
//            {
//                var pos = positions.First();
//                map.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(2)));
//                var reg = map.VisibleRegion;
//                var format = "0.00";
//            }
//            else
//            {
//                await this.DisplayAlert("Not found", "Geocoder returns no results", "Close");
//            }
            //   await Task.Delay(1000); // workaround for #30 [Android]Map.Pins.Add doesn't work when page OnAppearing

            //            var pin = new Pin()
            //            {
            //                Type = PinType.Place,
            //                Label = "Tokyo SKYTREE",
            //                Address = "Sumida-ku, Tokyo, Japan",
            //                Position = new Position(35.71d, 139.81d),
            //                Icon = BitmapDescriptorFactory.FromView(new BindingPinView(pinDisplay.Text))
            //            };
            //            map.Pins.Add(pin);
            //            pinDisplay.TextChanged += (sender, e) =>
            //            {
            //                pin.Icon = BitmapDescriptorFactory.FromView(new BindingPinView(e.NewTextValue));
            //            };
        }

    }
}
