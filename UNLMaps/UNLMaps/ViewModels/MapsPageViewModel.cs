using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;

namespace UNLMaps.ViewModels
{
    public class MapsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MapsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
