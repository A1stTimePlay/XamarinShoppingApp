﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.ViewModels.Transaction;

namespace XamarinShoppingApp.Views.Transaction
{
    /// <summary>
    /// Page to show the payment failure.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentFailurePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFailurePage" /> class.
        /// </summary>
        public PaymentFailurePage()
        {
            InitializeComponent();
            BindingContext = new PaymentViewModel();
        }
    }
}