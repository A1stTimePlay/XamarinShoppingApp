using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinShoppingApp.Views.Login;
using XamarinShoppingApp.Models;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Text;
using Newtonsoft.Json;
using IdentityModel.Client;
using FluentValidation;
using XamarinShoppingApp.Models;
namespace XamarinShoppingApp.ViewModels.Login
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
                Password = Password, 
            };
            var validationResults = _validator.Validate(userObj);

            if (validationResults.IsValid)
            {
                //App.Current.MainPage.DisplayAlert("FluentValidation", "Validation Success..!!", "Ok");
                string username = Name.ToString();
                string email = Email.ToString();
                string password = Password.ToString();
                string confirmPassword = ConfirmPassword.ToString();
                if(!password.Equals(confirmPassword))
                {
                    App.Current.MainPage.DisplayAlert("Thông báo", "password not matching ", "ok");
                }
                else
                {
                    var client = new HttpClient();
                    object userInfos = new { username = username, pass_word = password, email = email };
                    var jsonObj = JsonConvert.SerializeObject(userInfos);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("http://192.168.42.85:3000/Users", content).ConfigureAwait(false);
                    Console.WriteLine(result.StatusCode);
                    if (result.IsSuccessStatusCode)
                    {
                        var tokenJson = await result.Content.ReadAsStringAsync();
                        Console.WriteLine("singup thanh cong roi nhe!");
                        //App.Current.MainPage.DisplayAlert("Thông báo", "Đăng ký thành công! ", "Ok");

                    }
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("FluentValidation", validationResults.Errors[0].ErrorMessage, "Ok");
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
            
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        public async void SignUpClicked(object obj)
        {
            
            string username = Name.ToString();
            string email = Email.ToString();
            string password = Password.ToString();
            
            //Console.WriteLine(username.Equals(""));
          //  if(username.Equals("")==true||email==""|| password=="")
          //  {
          //      Console.WriteLine("khong singup duoc nhe");
            //    return;
         //   }
         
            var client = new HttpClient();
            object userInfos = new {  username = username, pass_word = password, email = email};
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://192.168.137.92:3000/Users", content).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var tokenJson = await result.Content.ReadAsStringAsync();
                Console.WriteLine("singup thanh cong roi nhe!");
                message = "Đăng ký thành công rồi nhé !";
                
            }
            

            #endregion
        }
    }
}