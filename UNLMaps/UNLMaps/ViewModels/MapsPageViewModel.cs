using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Realms;
using UNLMaps.Models;

namespace UNLMaps.ViewModels
{
    public class MapsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
      
        public readonly Realm _realm;

        public MapPin AddedMapPin;

        // Even though this is IEnumerable<User>, under the hood
        // it also implements INotifyCollectionChanged
        public IEnumerable<MapPin> MapPins { get; }


        #region DelegateCommands

        public DelegateCommand NavigateToCommand { get; set; }

        #endregion

        public MapsPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
           
            _realm = Realm.GetInstance("UNLRealm");

            MapPins = GetAllMapPins();

            // Delete an object with a transaction
//            using (var trans = _realm.BeginWrite())
//            {
//                foreach (var mP in MapPins.ToList())
//                {
//                    _realm.Remove(mP);
//                 
//                }
//                trans.Commit();
//            }
            NavigateToCommand = new DelegateCommand(NavigateTo);
        }

        /// <summary>
        /// Get all MapPins from DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MapPin> GetAllMapPins()
        {
            return _realm.All<MapPin>();
        }

        /// <summary>
        /// Get map pin by Id
        /// </summary>
        /// <param name="id"> MapPin Id</param>
        /// <returns></returns>
        public MapPin GetMapPinById(string id)
        {
            var findMapPin = _realm.All<MapPin>().FirstOrDefault(m => m.Id == id);
            return findMapPin;
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

            if (parameters.Count == 0) return;

            var newMapPin = parameters["AddedMapPin"] as MapPin;
            AddedMapPin = newMapPin;
        }

    }
}
