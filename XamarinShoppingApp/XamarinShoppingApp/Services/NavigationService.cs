using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinShoppingApp.Core.Services;
using XamarinShoppingApp.Services;
using XamarinShoppingApp.ViewModels;
using XamarinShoppingApp.ViewModels.Login;
using XamarinShoppingApp.Views.Login;
using XamarinShoppingApp;

namespace xaaasadsdadasd.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> MappingPageAndViewModel;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService()
        {
            MappingPageAndViewModel = new Dictionary<Type, Type>();

            SetPageViewModelMappings();
        }

        public async void NavigateBack()
        {
            await CurrentApplication.MainPage.Navigation.PopAsync(true);
        }

        public async void NavigateTo(Type type, string parameterName, string parameterValue, bool replaceView = false)
        {
           /*
            if (type == typeof(SignUpPageViewModel) && string.IsNullOrEmpty(parameterValue))
            {
                CurrentApplication.MainPage = new AppShell();
                return;
            }
            if (!replaceView)
            {
                await CurrentApplication.MainPage.Navigation.PushAsync(GetPageWithBindingContext(type, parameterName, parameterValue), true);
            }
            else
            {
                CurrentApplication.MainPage = new NavigationPage(GetPageWithBindingContext(type, parameterName, parameterValue));
            }
            */
        }

        private void SetPageViewModelMappings()
        {
            MappingPageAndViewModel.Add(typeof(LoginPageViewModel), typeof(SimpleLoginPage));
            MappingPageAndViewModel.Add(typeof(SignUpPageViewModel), typeof(SimpleSignUpPage));
        }

        /*
        public Page GetPageWithBindingContext(Type type, string parameterName, string parameterValue)
        {
            Type pageType = GetPageForViewModel(type);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {type} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;

            if (string.IsNullOrEmpty(parameterName))
            {
                page.BindingContext = TypeLocator.Instance.Resolve(type) as BaseViewModel;
            }
            else
            {
                page.BindingContext = TypeLocator.Instance.Resolve(type, new Autofac.NamedParameter(parameterName, parameterValue)) as BaseViewModel;
            }

            return page;
        }
        */
        internal Page GetPageWithBindingContext(int mainPage, string empty1, string empty2)
        {
            throw new NotImplementedException();
        }

        private Type GetPageForViewModel(Type viewModelType)
        {
            if (!MappingPageAndViewModel.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return MappingPageAndViewModel[viewModelType];
        }

        void INavigationService.NavigateToAsync(Type type, string parameterName, string parameterValue, bool replaceView)
        {
            throw new NotImplementedException();
        }
    }
}