using System;
using XamarinShoppingApp.Core.Services;
using XamarinShoppingApp.ViewModels.Forms;
namespace XamarinShoppingApp.Core
{
    public class Startup
    {
        IPreferenceService preferenceService;

        public Startup(IPreferenceService preferenceService)
        {
            this.preferenceService = preferenceService;
        }

        public Type GetMainPage()
        {
            var isNew = preferenceService.Get("isnew");
            //if (isNew == "false")
            if (true)
            {
                preferenceService.Set("isnew", "false");
                return typeof(SignUpPageViewModel);
            }
            else
            {
                var email = preferenceService.Get("email");

                if (string.IsNullOrEmpty(email))
                {
                    return typeof(LoginPageViewModel);
                }
                else
                {
                    return typeof(SignUpPageViewModel);
                }
            }
        }
    }
}