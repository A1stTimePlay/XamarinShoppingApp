using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Core.Services
{
    public interface IPreferenceService
    {
        void Set(string key, string value);

        string Get(string key);
    }
}
