using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using UNLMaps.Models;

namespace UNLMaps.ViewModels
{
    public class CreatePinPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly Realm _realm;

        private string name;
        private string address;
        private string description;

        private string selectedRaiting;


        private List<string> raitings;

        #region Properties

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public List<string> Raitings
        {
            get { return raitings; }
            set { SetProperty(ref raitings, value); }
        }

        public string SelectedRaiting
        {
            get { return selectedRaiting; }
            set { SetProperty(ref selectedRaiting, value); }
        }

        #endregion

        #region DelegateCommands

        public DelegateCommand AddPinCommand { get; set; }

        #endregion

        public CreatePinPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _realm = Realm.GetInstance("UNLRealms");

            Raitings = new List<string>
            {
                "1 ★", "2 ★", "3 ★", "4 ★", "5 ★", "6 ★", "7 ★", "8 ★", "9 ★", "10 ★"
            };

            AddPinCommand = new DelegateCommand(AddPin);
        }

        /// <summary>
        /// Save pin in local DB 
        /// </summary>
        private async void AddPin()
        {
            var newMapPin = new MapPin
            {
                Address = Address,
                Name = Name,
                Description = Description,
                Raiting = SelectedRaiting
            };

            _realm.Write(()=> _realm.Add(newMapPin));

            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("AddedMapPin", newMapPin);

            await _navigationService.GoBackAsync(parameters);
        }
    }
}
