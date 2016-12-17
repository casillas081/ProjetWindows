using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GuidMe1.Error;
using GuidMe1.Model;
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
        private String _pseudo;

        public String Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value;
                RaisePropertyChanged("Pseudo");
            }
        }

        private String _password;

        public String Password
        {
            get { return _password; }
            set { _password = value;
                RaisePropertyChanged("Password");
            }
        }

        private string _token;

        public string Token
        {
            get { return _token; }
            set { _token = value;
                RaisePropertyChanged("Token");
            }
        }


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
            
            if(Pseudo != null && Password != null)
            {
                _navigationService.NavigateTo("RoleChoiceScreen", Token);
                //GetToken(Pseudo, Password);
            }
        }

        public async Task GetToken(string _pseudo, string _password)
        {
            var service = new DataService();
            ApplicationError error = await service.GetToken(Pseudo, Password);
            if (error.IsOk)
            {
                var x2 = service.GetPerson();
                _navigationService.NavigateTo("RoleChoiceScreen",Token);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Status de la requête : " + error.ErrorMessage);
                dialog.ShowAsync();
            }
        }


    }
}
