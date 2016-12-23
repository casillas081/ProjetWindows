using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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


        private INavigationService _navigationService;

        public ParameterGuidScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            MyPlaceDoVisit = new ObservableCollection<string>();
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            var service = new DataService();
            var myPlaceDoVisit = await service.GetPlace(); // Appel au service
            thePlaceDoVisit = new ObservableCollection<TranslationPlace>(myPlaceDoVisit);
            foreach (TranslationPlace placed in myPlaceDoVisit)
            {
                MyPlaceDoVisit.Add(placed.TranslationNamePlace);
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

        private void GoToGuidScreen()
        {
            _navigationService.NavigateTo("GuidScreen");
        }
    }
}
