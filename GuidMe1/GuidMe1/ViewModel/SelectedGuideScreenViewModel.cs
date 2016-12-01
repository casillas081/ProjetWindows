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
    public class SelectedGuideScreenViewModel
    {
        private INavigationService _navigationService;

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

        private ICommand _goToGuidProfileCommand;

        public ICommand GoToGuidProfileCommand
        {
            get
            {
                if (_goToGuidProfileCommand == null)
                    _goToGuidProfileCommand = new RelayCommand(() => GoToGuidProfile());
                return _goToGuidProfileCommand;
            }
        }

        private void GoToGuidProfile()
        {
            _navigationService.NavigateTo("GuideProfile");
        }


        public SelectedGuideScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }
        

    }
}
