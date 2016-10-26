using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LogonScreenViewModel>();
            SimpleIoc.Default.Register<InscriptionScreenViewModel>();

            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);
            navigationPages.Configure("LogonScreen", typeof(LogonScreenViewModel));
            navigationPages.Configure("InscriptionScreen", typeof(InscriptionScreenViewModel));
        }

        public LogonScreenViewModel LogonScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogonScreenViewModel>();
            }
        }

        public InscriptionScreenViewModel InscriptionScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InscriptionScreenViewModel>();
            }
        }
    }
}
