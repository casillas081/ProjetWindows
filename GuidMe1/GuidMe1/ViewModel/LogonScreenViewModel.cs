using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GuidMe1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace GuidMe1.ViewModel
{
    public class LogonScreenViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public LogonScreenViewModel() {}

        private ICommand _goToInscriptionScreenCommand;

        public ICommand GoToInscriptionScreenCommand
        {
            get { if (_goToInscriptionScreenCommand == null)
                    _goToInscriptionScreenCommand = new RelayCommand(() => GoToInscriptionScreen());
                return _goToInscriptionScreenCommand;
                }
        }

        private ICommand _goToRoleChoiceScreenCommand;

        public ICommand GoToRoleChoiceScreenCommand
        {
            get {
                if (_goToRoleChoiceScreenCommand == null)
                    _goToRoleChoiceScreenCommand = new RelayCommand(() => GoToRoleChoiceScreen());
                return _goToRoleChoiceScreenCommand;
            }
        }
            

        private INavigationService _navigationService;

        [PreferredConstructor]
        public LogonScreenViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void GoToInscriptionScreen()
        {
            _navigationService.NavigateTo("InscriptionScreen");
        }

        private void GoToRoleChoiceScreen()
        {
            _navigationService.NavigateTo("RoleChoiceScreen");
        }


    }
}
