using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.Services;
using XamarinShoppingApp.Core.Services;
using XamarinShoppingApp.Views.Forms;
using XamarinShoppingApp.Views.Catalog;
using System.Text;

namespace XamarinShoppingApp.ViewModels.Forms
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
                else if (!string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
                    await Application.Current.MainPage.DisplayAlert("Password is null!", "Please input Password", "Ok");
                else if (string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                    await Application.Current.MainPage.DisplayAlert("Username is null!", "Please input Username", "Ok");
                string txt_email = Email.ToString().Trim();
                string txt_password = Password.ToString().Trim();
                if (!IsInvalidEmail)
                {
                    var httpClient = new HttpClient();
                    var getUserByEmail = await httpClient.GetStringAsync(App.BaseApiUrl + "user/email/" + txt_email);
                    List<User> user = JsonConvert.DeserializeObject<List<User>>(getUserByEmail);
                    if (user.Count > 0)
                    {
                        if (user[0].PASS_WORD.Equals(txt_password))
                        {
                            App.CurrentUser = user[0];

                            string id_user = user[0].ID.ToString();
                            string order_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            await Application.Current.MainPage.Navigation.PushAsync(new ProductHomePage());

                            //tạo order mới trên server
                            object new_order = new { id_user = id_user, order_date = order_date };
                            var jsonObj = JsonConvert.SerializeObject(new_order);
                            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                            var result = await httpClient.PostAsync(App.BaseApiUrl + "order", content).ConfigureAwait(false);

                            //lưu order vừa tạo để sử dụng sau
                            string str = $"?id_user={id_user}&order_date={order_date}";
                            var getOrderByIdUserAndOrderDate = await httpClient.GetStringAsync(App.BaseApiUrl + "order" + str);
                            List<Order> order = JsonConvert.DeserializeObject<List<Order>>(getOrderByIdUserAndOrderDate);
                            App.CurrentOrder = order[0];
                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Username or Password is wrong!", "Please input again", "Ok");
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Username or Password is wrong!", "Please input again", "Ok");

                }
                else
                {
                    Console.WriteLine("Invalid email");
                }
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