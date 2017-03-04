using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;

namespace UNLMaps.ViewModels
{
    public class CreatePinPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string name;
        private string address;
        private string description;
        private int raiting;

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

        public int Raiting
        {
            get { return raiting; }
            set { SetProperty(ref raiting, value); }
        }

        #endregion

        #region DelegateCommands

        public DelegateCommand AddPinCommand { get; set; }

        #endregion

        public CreatePinPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AddPinCommand = new DelegateCommand(AddPin);
        }

        /// <summary>
        /// Save pin in local DB 
        /// </summary>
        private async void AddPin()
        {
            var n = Name;
            var a = Address;
            var d = Description;
            var r = Raiting;
            await _navigationService.GoBackAsync();
        }
    }
}
