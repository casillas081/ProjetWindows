using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.ViewModel
{
    public class ParameterGuidScreenViewModel
    {
        private INavigationService _navigationService;

        public ParameterGuidScreenViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }
    }
}
