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
    public class InscriptionScreenViewModel
    {
        private INavigationService _navigationService;

        public InscriptionScreenViewModel(INavigationService navigationService=null)
        {
            _navigationService = navigationService;
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {

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
