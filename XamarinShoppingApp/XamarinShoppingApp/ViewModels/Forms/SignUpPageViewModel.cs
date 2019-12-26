using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.Views.Forms;

namespace XamarinShoppingApp.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields

        private string name;

        private string password;

        private string confirmPassword;

        #endregion

        #region Constructor

        readonly IValidator _validator;

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            _validator = new validateUser();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.ValidateUserInfo);
        }

        #endregion

        #region Property

        async void ValidateUserInfo()
        {
            var userObj = new User
            {
                Username = Name,
                Email = Email,
                PASS_WORD = Password,
            };
            var validationResults = _validator.Validate(userObj);

            if (validationResults.IsValid)
            {
                //App.Current.MainPage.DisplayAlert("FluentValidation", "Validation Success..!!", "Ok");
                string username = Name.ToString();
                string email = Email.ToString();
                string password = Password.ToString();
                string confirmPassword = ConfirmPassword.ToString();
                if (!password.Equals(confirmPassword))
                {
                    await App.Current.MainPage.DisplayAlert("Thông báo", "password not matching ", "ok");
                }
                else
                {
                    var client = new HttpClient();
                    object userInfos = new { username = username, pass_word = password, email = email };
                    var jsonObj = JsonConvert.SerializeObject(userInfos);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(App.BaseApiUrl + "Users", content).ConfigureAwait(false);
                    Console.WriteLine(result.StatusCode);
                    if (result.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new SimpleLoginPage());

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Thông báo", "Username hoặc Email đã có trên hệ thống", "ok");
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("FluentValidation", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password confirmation from users in the Sign Up page.
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                if (this.confirmPassword == value)
                {
                    return;
                }

                this.confirmPassword = value;
                this.NotifyPropertyChanged();
            }
        }

        public string message { get; set; }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>

        #endregion
    }
}