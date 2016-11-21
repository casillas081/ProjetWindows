using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuidMe1.ViewModel
{
    public class ParameterGuidScreenViewModel
    {
        private INavigationService _navigationService;

        public ParameterGuidScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

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

        private void GoToGuidScreen()
        {
            _navigationService.NavigateTo("GuidScreen");
        }
    }
}
