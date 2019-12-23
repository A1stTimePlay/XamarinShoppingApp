using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinShoppingApp.Models;
using xaaasadsdadasd.Services;
using XamarinShoppingApp.Core.Services;
using XamarinShoppingApp.Views.Login;

namespace XamarinShoppingApp.ViewModels.Login
{
    
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields

        private string password;
        //public INavigationService navigationService = new NavigationService();
        SimpleLoginPage simpleLoginPage;

        //IDialogService dialogService;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            //this.simpleLoginPage = simpleLoginPage;
            this.LoginCommand = new Command(this.LoginClickedAsync);
            this.SignUpCommand = new Command(this.SignUpClickedAsync);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
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

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        public string Message { get; set; }
        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClickedAsync(object obj)
        {
           
            try
            {

                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
                   await Application.Current.MainPage.DisplayAlert("Username and Password are null!", "Please input Username and Password", "Ok");
                else if(!string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
                    await Application.Current.MainPage.DisplayAlert("Password is null!", "Please input Password", "Ok");
                else if(string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                    await Application.Current.MainPage.DisplayAlert("Username is null!", "Please input Username", "Ok");
                string txt_username = Email.ToString().Trim();
                string txt_password = Password.ToString().Trim();
                var httpClient = new HttpClient();
                //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                var respone = await httpClient.GetStringAsync("http://10.45.241.165:3000/user/" + txt_username);
                Console.WriteLine(respone);
                List<User> user = JsonConvert.DeserializeObject<List<User>>(respone);
                Console.WriteLine("Count of user is :"+user.Count);
                if (user.Count>0)
                {
                    if (user[0].PASS_WORD.Equals(txt_password))
                            await Application.Current.MainPage.Navigation.PushAsync(new SimpleSignUpPage());   
                    
                    else
                        await Application.Current.MainPage.DisplayAlert("Username or Password is wrong!", "Please input again", "Ok");
                }
                else 
                    await Application.Current.MainPage.DisplayAlert("Username or Password is wrong!", "Please input again", "Ok");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }


        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SignUpClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SimpleSignUpPage());
            // Do something
            //navigationService.NavigateTo(typeof(SignUpPageViewModel), string.Empty, string.Empty, false);
            var client = new HttpClient();
            var content = new StringContent(
                 JsonConvert.SerializeObject(new { USERNAME = "myusername", PASS_WORD = "mypass", EMAIL = "123@gmail.com" }));
            Console.WriteLine("toi day!");
            Console.WriteLine(content);
            var result = await client.PostAsync("http://10.10.99.121:3000/Users", content).ConfigureAwait(false);

            Console.WriteLine("chạy tới đây rồi nhé!");
            Console.WriteLine(result);
            if (result.IsSuccessStatusCode)
            {
                var tokenJson = await result.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            // Do something
        }

        #endregion
    }
}