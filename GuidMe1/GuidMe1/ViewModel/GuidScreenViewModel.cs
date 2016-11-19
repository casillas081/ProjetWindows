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

        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
