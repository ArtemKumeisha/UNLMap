using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;

namespace UNLMaps.ViewModels
{
    public class MapsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region DelegateCommands

        public DelegateCommand NavigateToCommand { get; set; }

        #endregion

        public MapsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToCommand = new DelegateCommand(NavigateTo);
        }

        /// <summary>
        /// Method navigate to CreatePinPage
        /// </summary>
        private async void NavigateTo()
        {
            await _navigationService.NavigateAsync("CreatePinPage");
        }
    }
}
