using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
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

        private String _pseudo;

        public String Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value;
                RaisePropertyChanged("Pseudo");
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

        private String _verifPassword;

        public String VerifPassword
        {
            get { return _verifPassword; }
            set { _verifPassword = value; }
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

        private List<String> _placeForVisit;

        public List<String> PlaceForVisit
        {
            get { return _placeForVisit; }
            set { _placeForVisit = value;
                RaisePropertyChanged("PlaceForVisit");
            }
        }

        private List<String> _placeDoVisit;

        public List<String> PlaceDoVisit
        {
            get { return _placeDoVisit; }
            set { _placeDoVisit = value;
                RaisePropertyChanged("PlaceDoVisit");
            }
        }
        

        private INavigationService _navigationService;

        [PreferredConstructor]
        public InscriptionScreenViewModel(INavigationService navigationService=null)
        {
            MyNationality = new List<String> { "Afghan", "Belge", "Dutch"};
            InitializeAsync();
            _navigationService = navigationService;
        }

        public async Task InitializeAsync()
        {
            var service = new DataService();
            var listPlaceForVisit = await service.GetPlace(); // Appel au service
            PlaceForVisit = new List<String>();
            foreach(TranslationPlace placed in listPlaceForVisit)
            {
                PlaceForVisit.Add(placed.TranslationNamePlace);
            }
            var placeDoVisit = await service.GetPlace(); // Appel au service
            PlaceDoVisit = new List<String>();
            foreach(TranslationPlace placede in placeDoVisit)
            {
                PlaceDoVisit.Add(placede.TranslationNamePlace);
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

        private void GoToRoleChoiceScreen()
        {
                var person = new Person(Pseudo, Password, FirstName, LastName, Sex, Nationality);
                var service = new DataService();
                var id = service.AddNewUser(person);
                _navigationService.NavigateTo("RoleChoiceScreen");        
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
