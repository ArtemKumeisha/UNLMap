using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Realms;
using UNLMaps.ViewModels;
using UNLMaps.Views.CustomLayouts;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace UNLMaps.Views
{
    public partial class MapsPage : ContentPage
    {
        private MapsPageViewModel mpVM;

        private Geocoder geocoder;

        private bool isStart;

        public MapsPage()
        {
            InitializeComponent();
            mpVM = this.BindingContext as MapsPageViewModel;
            InitializeMap();
            isStart = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if(!mpVM.MapPins.Any() || isStart) return;

            var addedPin = mpVM.MapPins.LastOrDefault();

            AddPinToMap(addedPin.Address, addedPin.Name, addedPin.Description, $"{addedPin.Raiting}");
    
        }

        /// <summary>
        /// Method populate Pin to Map
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="raiting"></param>
        private async void AddPinToMap(string address, string name, string  description, string raiting)
        {
            Position pinPosition = new Position();

            var pinPositions = await geocoder.GetPositionsForAddressAsync(address);

            if (pinPositions != null && pinPositions.Any())
            {
                pinPosition = pinPositions.First();
            }

            await Task.Delay(1000); // workaround for #30 [Android]Map.Pins.Add doesn't work when page OnAppearing

            var pin = new Pin
            {
                Address = address,
                Position = pinPosition,
                Icon = BitmapDescriptorFactory.FromView(new BindingPinView("")),
                Label = $"{name}, {description}, {raiting}"
            };

            map.Pins.Add(pin);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPosition, Distance.FromKilometers(1)));
            
        }

        /// <summary>
        /// Initialize GoogleMaps 
        /// </summary>
        private async void InitializeMap()
        {
            try
            {
                geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();
                var positions = await geocoder.GetPositionsForAddressAsync("Belarus");
                if (positions.Any())
                {
                    var pos = positions.First();
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(2)));
                    map.IsShowingUser = true;
                    
                    if (mpVM.MapPins.Any() && isStart)
                    {
                        var indicator = new IndicatorLayout();
                        MainLayout.Children.Add(indicator);

                        int count = mpVM.MapPins.Count();
                        foreach (var mp in mpVM.MapPins)
                        {
                            count--;
                            Position pinPosition = new Position();

                            var pinPositions = await geocoder.GetPositionsForAddressAsync(mp.Address);

                            if (pinPositions != null && pinPositions.Any())
                            {
                                pinPosition = pinPositions.First();
                            }

                            await Task.Delay(1000); // workaround for #30 [Android]Map.Pins.Add doesn't work when page OnAppearing

                            var pin = new Pin
                            {
                                Address = mp.Address,
                                Position = pinPosition,
                                Icon = BitmapDescriptorFactory.FromView(new BindingPinView("")),
                                Label = $"{mp.Name}, {mp.Description}, {mp.Raiting}"
                            };

                            map.Pins.Add(pin);

                            if (count == 0)
                               map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPosition, Distance.FromKilometers(1)));
                            
                        }

                        isStart = false;
                        MainLayout.Children.Remove(indicator);
                    }
                }
                else
                {
                    await this.DisplayAlert("Not found", "Geocoder returns no results", "Close");
                }
            }
            catch (Exception e)
            {
                await this.DisplayAlert("Not found", e.Message + " Check your internet", "Close");
            }
           
        }

    }
}
