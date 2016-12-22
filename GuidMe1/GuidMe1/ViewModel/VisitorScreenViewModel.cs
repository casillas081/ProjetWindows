using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GuidMe1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace GuidMe1.ViewModel
{
    public class VisitorScreenViewModel : ViewModelBase
    {
        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                RaisePropertyChanged("Person");
            }
        }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                if (_selectedPerson != null)
                {
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }

        private ICommand _goToParameterVisitorCommand;

        public ICommand GoToParameterVisitorCommand
        {
            get
            {
                if (_goToParameterVisitorCommand == null)
                    _goToParameterVisitorCommand = new RelayCommand(() => GoToParameterVisitorScreen());
                return _goToParameterVisitorCommand;
            }
        }

        private ICommand _goToListGuideToEvaluateCommand;

        public ICommand GoToListGuideToEvaluateCommand
        {
            get
            {
                if (_goToListGuideToEvaluateCommand == null)
                    _goToListGuideToEvaluateCommand = new RelayCommand(() => GoToListGuideToEvaluateScreen());
                return _goToListGuideToEvaluateCommand;
            }
        }

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

        //CONSTRUCTOR
        public VisitorScreenViewModel(INavigationService navigationService = null)
        {
            //Persons = new ObservableCollection<Person>(AllPersons.GetAllPersons());
            _navigationService = navigationService;
        }


        private void GoToParameterVisitorScreen()
        {
            _navigationService.NavigateTo("ParameterVisitorScreen");
        }

        private void GoToListGuideToEvaluateScreen()
        {
            _navigationService.NavigateTo("ListGuideToEvaluateScreen");
        }

    }
}
