using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GuidMe1.Dao;
using GuidMe1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuidMe1.ViewModel
{
    public class ParameterGuidScreenViewModel : ViewModelBase
    {

        public ObservableCollection<String> MyPlaceDoVisit { get; set; }

        private String _placeDoVisit;

        public String PlaceDoVisit
        {
            get { return _placeDoVisit; }
            set
            {
                _placeDoVisit = value;
                RaisePropertyChanged("PlaceDoVisit");
            }
        }

        public ObservableCollection<String> ListWantDoVisit { get; set; }

        private String _listDoVisit;

        public String ListDoVisit
        {
            get { return _listDoVisit; }
            set { _listDoVisit = value;
                RaisePropertyChanged("ListDoVisit");
            }
        }

        private Person _currentUser;

        public Person CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        

        public ObservableCollection<TranslationPlace> thePlaceDoVisit { get; set; }
        public ObservableCollection<TranslationPlace> myListPlaceDoVisit { get; set; }

        public ObservableCollection<Want_To_Guid> CompatilityUser { get; set; }
        private ICommand _refreshScreen;

        public ICommand RefreshScreen
        {
            get
            {
                if (_refreshScreen == null)
                    _refreshScreen = new RelayCommand(() => DoRefreshScreen());
                return _refreshScreen;
            }
        }


        private INavigationService _navigationService;

        public ParameterGuidScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            MyPlaceDoVisit = new ObservableCollection<string>();
            ListWantDoVisit = new ObservableCollection<string>();
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            var guideService = new GuideService();
            var service = new DataService();
            var myPlaceDoVisit = await service.GetPlace(); // Appel au service
            thePlaceDoVisit = new ObservableCollection<TranslationPlace>(myPlaceDoVisit);
            foreach (TranslationPlace placed in myPlaceDoVisit)
            {
                MyPlaceDoVisit.Add(placed.TranslationNamePlace);
            }

            CurrentUser = await service.GetPerson();
            var service2 = new GuideService();
            var wantDoVisit = await service2.GetWantDoVisit();
            foreach(Want_To_Guid wtg in wantDoVisit)
            {
                if (wtg.Person.Email.Equals(CurrentUser.Email))
                {
                    CompatilityUser = new ObservableCollection<Want_To_Guid>(wantDoVisit);
                }
            }

            var myListPlaceDoVisited = await service.GetPlace();
            myListPlaceDoVisit = new ObservableCollection<TranslationPlace>(myListPlaceDoVisited);
            foreach (Want_To_Guid wantToGuide in CompatilityUser)
            {
                foreach(TranslationPlace placeded in myListPlaceDoVisit)
                {
                    if (wantToGuide.Place.IdPlace.Equals(placeded.Place.IdPlace))
                    {
                        ListWantDoVisit.Add(placeded.TranslationNamePlace);
                    }
                }
            }

        }

        private ICommand _goToGuidScreenCommand;

        public ICommand GoToGuidScreenCommand
        {
            get
            {
                if (_goToGuidScreenCommand == null)
                    _goToGuidScreenCommand = new RelayCommand(() => GoToGuidScreen());
                return _goToGuidScreenCommand;
            }
        }

        private void DoRefreshScreen() { 
}

        private void GoToGuidScreen()
        {
            _navigationService.NavigateTo("GuidScreen");
        }
    }
}
