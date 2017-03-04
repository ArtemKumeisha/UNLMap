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
    public class MapsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        private readonly Realm _realm;

        // Even though this is IEnumerable<User>, under the hood
        // it also implements INotifyCollectionChanged
        public IEnumerable<MapPin> MapPins { get; }


        #region DelegateCommands

        public DelegateCommand NavigateToCommand { get; set; }

        #endregion

        public MapsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _realm = Realm.GetInstance("UNLRealm");

            MapPins = _realm.All<MapPin>();

            // Delete an object with a transaction
//            using (var trans = _realm.BeginWrite())
//            {
//                foreach (var mP in MapPins)
//                {
//                    _realm.Remove(mP);
//                 
//                }
//                trans.Commit();
//            }
//
//            MapPins = _realm.All<MapPin>();
            var count = MapPins.Count();
            NavigateToCommand = new DelegateCommand(NavigateTo);
        }

        /// <summary>
        /// Method navigate to CreatePinPage
        /// </summary>
        private async void NavigateTo()
        {
            await _navigationService.NavigateAsync("CreatePinPage");
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.Count != 0)
            {
                var b = parameters;
            }
          
        }

    }
}
