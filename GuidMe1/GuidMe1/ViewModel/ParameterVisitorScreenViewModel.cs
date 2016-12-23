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
    public class ParameterVisitorScreenViewModel : ViewModelBase
    {
        public ObservableCollection<String> MyPlaceForVisit { get; set; }

        private String _placeForVisit;

        public String PlaceForVisit
        {
            get { return _placeForVisit; }
            set
            {
                _placeForVisit = value;
                RaisePropertyChanged("PlaceForVisit");
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


        public ObservableCollection<TranslationPlace> thePlaceForVisit { get; set; }

        private ICommand _goToRoleChoiceScreenCommand;

        public ICommand GoToRoleChoiceScreenCommand
        {
            get
            {
                if (_goToRoleChoiceScreenCommand == null)
                    _goToRoleChoiceScreenCommand = new RelayCommand(() => GoToRoleChoiceScreen());
                return _goToRoleChoiceScreenCommand;
            }
        }

        private void GoToRoleChoiceScreen()
        {
            _navigationService.NavigateTo("RoleChoiceScreen");
        }

        private INavigationService _navigationService;

        public ParameterVisitorScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            MyPlaceForVisit = new ObservableCollection<string>();
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            var service = new DataService();
            var myPlaceForVisit = await service.GetPlace(); // Appel au service
            thePlaceForVisit = new ObservableCollection<TranslationPlace>(myPlaceForVisit);

            foreach (TranslationPlace placed in myPlaceForVisit)
            {
                MyPlaceForVisit.Add(placed.TranslationNamePlace);
            }

        }
    }
}
