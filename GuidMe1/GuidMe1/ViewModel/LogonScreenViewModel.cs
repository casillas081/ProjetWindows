using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GuidMe1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuidMe1.ViewModel
{
    public class LogonScreenViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        public LogonScreenViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //private ICommand _goToInscriptionScreenCommand;

        //public ICommand GoToInscriptionScreenCommand
        //{
        //    get {
        //        _goToInscriptionScreenCommand = new RelayCommand( () => GoToInscriptionScreen());
                
        //        return _goToInscriptionScreenCommand;
        //    }
        //}

        //private void GoToInscriptionScreen()
        //{
        //    _navigationService.NavigateTo("InscriptionScreen");
        //}

    }
}
