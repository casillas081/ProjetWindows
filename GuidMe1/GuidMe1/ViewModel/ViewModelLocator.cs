using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GuidMe1.View;
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
            SimpleIoc.Default.Register<RoleChoiceScreenViewModel>();
            SimpleIoc.Default.Register<GuidScreenViewModel>();
            SimpleIoc.Default.Register<ParameterGuidScreenViewModel>();
            SimpleIoc.Default.Register<VisitorScreenViewModel>();
            SimpleIoc.Default.Register<ParameterVisitorScreenViewModel>();
            SimpleIoc.Default.Register<ListGuideToEvaluateScreenViewModel>();
            SimpleIoc.Default.Register<EvaluationMatchedGuideViewModel>();
            SimpleIoc.Default.Register<GuideProfileViewModel>();
            SimpleIoc.Default.Register<SelectedGuideScreenViewModel>();

            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);

            navigationPages.Configure("LogonScreen", typeof(LogonScreen));
            navigationPages.Configure("InscriptionScreen", typeof(InscriptionScreen));
            navigationPages.Configure("RoleChoiceScreen", typeof(RoleChoiceScreen));
            navigationPages.Configure("GuidScreen", typeof(GuidScreen));
            navigationPages.Configure("ParameterGuidScreen", typeof(ParameterGuidScreen));
            navigationPages.Configure("VisitorScreen", typeof(VisitorScreen));
            navigationPages.Configure("ParameterVisitorScreen", typeof(ParameterVisitorScreen));
            navigationPages.Configure("ListGuideToEvaluateScreen", typeof(ListGuideToEvaluateScreen));
            navigationPages.Configure("EvaluationMatchedGuide", typeof(EvaluationMatchedGuide));
            navigationPages.Configure("GuideProfile", typeof(GuideProfile));
            navigationPages.Configure("SelectedGuideScreen", typeof(SelectedGuideScreen));

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

        public RoleChoiceScreenViewModel RoleChoiceScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoleChoiceScreenViewModel>();
            }
        }

        public GuidScreenViewModel GuidScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GuidScreenViewModel>();
            }
        }

        public ParameterGuidScreenViewModel ParameterGuidScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ParameterGuidScreenViewModel>();
            }
        }

        public VisitorScreenViewModel VisitorScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VisitorScreenViewModel>();
            }
        }

        public ParameterVisitorScreenViewModel ParameterVisitorScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ParameterVisitorScreenViewModel>();
            }
        }

        public ListGuideToEvaluateScreenViewModel ListGuideToEvaluateScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListGuideToEvaluateScreenViewModel>();
            }
        }

        public EvaluationMatchedGuideViewModel EvaluationMatchedGuideScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EvaluationMatchedGuideViewModel>();
            }
        }

        public GuideProfileViewModel GuideProfile
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GuideProfileViewModel>();
            }
        }

        public SelectedGuideScreenViewModel SelectedGuideScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelectedGuideScreenViewModel>();
            }
        }

    }
}
