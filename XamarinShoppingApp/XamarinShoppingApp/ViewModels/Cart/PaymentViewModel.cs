using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.Views.Catalog;

namespace XamarinShoppingApp.ViewModels.Transaction
{
    /// <summary>
    /// ViewModel for Payment page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class PaymentViewModel
    {
        #region Fields

        private string paymentSuccessIcon;
        private string paymentFailureIcon;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="PaymentViewModel"/> class.
        /// </summary>
        public PaymentViewModel()
        {
            this.paymentSuccessIcon = "PaymentSuccess.svg";
            this.paymentFailureIcon = "PaymentFailure.svg";
            this.TrackOrderCommand = new Command(this.TrackOrderClicked);
            this.MakePaymentCommand = new Command(this.MakePaymentClicked);
        }
        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that will be executed when track order button is clicked.
        /// </summary>
        public Command TrackOrderCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when make payment button is clicked.
        /// </summary>
        public Command MakePaymentCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the payment success icon.
        /// </summary>
        public string PaymentSuccessIcon
        {
            get
            {
                return this.paymentSuccessIcon;
            }

            set
            {
                this.paymentSuccessIcon = value;
            }
        }

        /// <summary>
        /// Gets or sets the payment failure icon.
        /// </summary>
        public string PaymentFailureIcon
        {
            get
            {
                return this.paymentFailureIcon;
            }

            set
            {
                this.paymentFailureIcon = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when track order button is clicked.
        /// </summary>
        private async void TrackOrderClicked(object obj)
        {
            // Do something
            HttpClient httpClient = new HttpClient();

            string id_user = App.CurrentUser.ID.ToString();
            string order_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            await Application.Current.MainPage.Navigation.PushAsync(new ProductHomePage());

            //tạo order mới trên server
            object new_order = new { id_user = id_user, order_date = order_date };
            var jsonObj = JsonConvert.SerializeObject(new_order);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(App.BaseApiUrl + "order", content).ConfigureAwait(false);

            //update order confirmation trên server
            object confirmation = new { confirmation = "1" };
            var jsonConfirmation = JsonConvert.SerializeObject(confirmation);
            var contentConfirmation = new StringContent(jsonConfirmation, Encoding.UTF8, "application/json");
            var resultConfirmation = await httpClient.PutAsync(App.BaseApiUrl + "order/" + App.CurrentOrder.Id, contentConfirmation).ConfigureAwait(false);

            //lưu order vừa tạo để sử dụng sau
            string str = $"?id_user={id_user}&order_date={order_date}";
            var getOrderByIdUserAndOrderDate = await httpClient.GetStringAsync(App.BaseApiUrl + "order" + str);
            List<Order> order = JsonConvert.DeserializeObject<List<Order>>(getOrderByIdUserAndOrderDate);
            App.CurrentOrder = order[0];


        }

        /// <summary>
        /// Invoked when make payment button is clicked.
        /// </summary>
        private void MakePaymentClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
