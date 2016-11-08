using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace GuidMe1.ViewModel
{
    public class RoleChoiceScreenViewModel
    {

        private INavigationService _navigationService;

        public RoleChoiceScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
