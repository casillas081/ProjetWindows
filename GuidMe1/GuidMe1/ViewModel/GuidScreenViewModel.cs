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
    public class GuidScreenViewModel
    {
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

        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
