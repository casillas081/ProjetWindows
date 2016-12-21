using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace GuidMe1.ViewModel
{
    public class GuidScreenViewModel : ViewModelBase
    {
        private Boolean _isOnline;

        public Boolean IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value;
                RaisePropertyChanged("IsOnline");
            }
        }

        private TimeSpan _timePicker;

        public TimeSpan TimePicker
        {
            get { return _timePicker; }
            set { _timePicker = value; }
        }


        private ICommand _timeOnline;

        public ICommand TimeOnline
        {
            get { _timeOnline = new RelayCommand(() => CalculateTimer());
                return _timeOnline;
            }
        }

        private async void CalculateTimer()
        {
            var sec = 60;
            var minutes = TimePicker.Minutes - 1;
            var heure = TimePicker.Hours;
            var decompte = true;
            while(decompte)
            {
                sec--;
                if (sec == 0 && minutes >= 0)
                {
                    minutes--;
                    sec = 60;
                    if (minutes >= 0 && heure > 0)
                    {
                        heure--;
                        minutes = 60;
                    }
                }
            }              
        }

        private ICommand _goToParameterGuidCommand;

        public ICommand GoToParameterGuidCommand
        {
            get
            {
                if (_goToParameterGuidCommand == null)
                    _goToParameterGuidCommand = new RelayCommand(() => GoToParameterGuidScreen());
                return _goToParameterGuidCommand;
            }
        }
        
        private INavigationService _navigationService;

        public GuidScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }


        private void GoToParameterGuidScreen()
        {
            _navigationService.NavigateTo("ParameterGuidScreen");
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

 
    }
}
