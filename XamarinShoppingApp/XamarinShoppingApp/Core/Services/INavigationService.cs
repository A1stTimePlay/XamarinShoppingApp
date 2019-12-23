using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Core.Services
{
    public interface INavigationService
    {
        void NavigateToAsync(Type type, string parameterName, string parameterValue, bool replaceView = false);

        void NavigateBack();

        void NavigateTo(Type type, string parameterName, string parameterValue, bool replaceView = false);
    }
}