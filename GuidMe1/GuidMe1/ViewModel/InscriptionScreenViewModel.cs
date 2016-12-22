using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GuidMe1.Error;
using GuidMe1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace GuidMe1.ViewModel
{
    public class InscriptionScreenViewModel : ViewModelBase
    {
        private String _firstName;

        public String FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private String _lastName;

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private bool _sex;

        public bool Sex
        {
            get { return _sex; }
            set { _sex = value;
                RaisePropertyChanged("Sex");  
            }
        }

        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private String _password;

        public String Password
        {
            get { return _password; }
            set { _password = value;
                RaisePropertyChanged("Password");
            }
        }

        private String _confirmPassword;

        public String ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value;
                RaisePropertyChanged("ConfirmPassword");
            }
        }


        public List<String> MyNationality { get; set; }


        private String _nationality;

        public String Nationality
        {
            get { return _nationality; }
            set { _nationality = value;
                RaisePropertyChanged("Nationality");
            }
        }

        public ObservableCollection<String> MyPlaceForVisit { get; set; }

        private String _placeForVisit;

        public String PlaceForVisit
        {
            get { return _placeForVisit; }
            set { _placeForVisit = value;
                RaisePropertyChanged("PlaceForVisit");
            }
        }

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
            set { _currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }


        public ObservableCollection<TranslationPlace> thePlaceForVisit { get; set; }

        public ObservableCollection<TranslationPlace> thePlaceDoVisit { get; set; }

        private INavigationService _navigationService;

        [PreferredConstructor]
        public InscriptionScreenViewModel(INavigationService navigationService=null)
        {
            MyNationality = new List<String> {"Afghan", "Belge", "Dutch"};
            _navigationService = navigationService;
            MyPlaceForVisit = new ObservableCollection<string>();
            MyPlaceDoVisit = new ObservableCollection<string>();
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

            var myPlaceDoVisit = await service.GetPlace(); // Appel au service
            thePlaceDoVisit = new ObservableCollection<TranslationPlace>(myPlaceDoVisit);
            foreach (TranslationPlace placede in myPlaceDoVisit)
            {
                MyPlaceDoVisit.Add(placede.TranslationNamePlace);
            }

        }

// Validation du Bouton, On envoit les données du formulaire, on vérifie qu'elles sont correctes vis à vis du type de valeur dans la BD dans le service
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

        private async void GoToRoleChoiceScreen()
        {
            var person =  new RegisterBindingModel(Email, Password, ConfirmPassword, FirstName, LastName, Sex, Nationality);
            var service = new DataService();
            var error1 = await service.AddNewUser(person);
            if (error1.IsOk)
            {
                var errorToken = await service.GetToken(person.Email, person.Password);
                if (errorToken.IsOk)
                {
                    var idPlace = "";
                    for (int i = 0; i < thePlaceForVisit.Count(); i++)
                    {
                        if (thePlaceForVisit[i].TranslationNamePlace.Equals(PlaceForVisit))
                        {
                            idPlace = thePlaceForVisit[i].Place.IdPlace;
                            break;
                        }
                    }
                    var placeConfirmed = await service.GetPlaceId(idPlace);
                    CurrentUser = await service.GetPerson();
                    Want_To_GuidCreateModel wantToGuid = new Want_To_GuidCreateModel(CurrentUser.Id, placeConfirmed.Address, placeConfirmed.IdPlace);
                    var error2 = await service.AddWantToGuide(wantToGuid);
                    if (error2.IsOk)
                    {
                        _navigationService.NavigateTo("RoleChoiceScreen");
                    }
                    else
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog("Status de la requête : " + error2.ErrorMessage);
                        dialog.ShowAsync();
                    }
                }
                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Status de la requête :" + errorToken.ErrorMessage);
                    dialog.ShowAsync();
                    _navigationService.NavigateTo("LogonScreen");
                }
                
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Status de la requête : " + error1.ErrorMessage);
                dialog.ShowAsync();
            }
            
            
        }
        // Bouton Retour a logon quand on ne veut pas 
        private ICommand _goToLogonScreenCommand;

        public ICommand GoToLogonScreenCommand
        {
            get {
                if (_goToLogonScreenCommand == null)
                    _goToLogonScreenCommand = new RelayCommand(() => GoToLogonScreen());
                return _goToLogonScreenCommand;
            }
        }

        private void GoToLogonScreen()
        {
            _navigationService.NavigateTo("LogonScreen");
        }

    }
}
