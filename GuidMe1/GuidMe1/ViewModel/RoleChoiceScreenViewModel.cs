using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
    public class RoleChoiceScreenViewModel
    {
        public RoleChoiceScreenViewModel(){}

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

        private INavigationService _navigationService;

        [PreferredConstructor]
        public RoleChoiceScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }       

        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void GoToGuidScreen()
        {
            _navigationService.NavigateTo("GuidScreen");
        }
    }
}
