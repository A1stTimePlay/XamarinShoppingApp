using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using XamarinShoppingApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinShoppingApp.Views.Bookmarks;

namespace XamarinShoppingApp.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DetailPageViewModel : BaseViewModel
    {
        #region Fields

        private readonly double productRating;

        private Product productDetail;

        private bool isFavourite;

        private bool isReviewVisible;

        private int? cartItemCount;

        public List<string> SizeVariants { get; set; } = new List<string> { "XS", "S", "M", "L", "XL" };

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="DetailPageViewModel" /> class.
        /// </summary>
        public DetailPageViewModel(Product selectedProduct)
        {
            ProductDetail = selectedProduct;
            this.AddToCartCommand = new Command(this.AddToCartClicked);
            this.ShareCommand = new Command(this.ShareClicked);
            this.VariantCommand = new Command(this.VariantClicked);
            this.ItemSelectedCommand = new Command(this.ItemSelected);
            this.CardItemCommand = new Command(this.CartClicked);
            this.LoadMoreCommand = new Command(this.LoadMoreClicked);
            CartItemCount = App.CurrentCart.Count();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with SfRotator and labels, which display the product images and details.
        /// </summary>
        public Product ProductDetail
        {
            get
            {
                return this.productDetail;
            }

            set
            {
                if (this.productDetail == value)
                {
                    return;
                }

                this.productDetail = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with StackLayout, which displays the categories using ComboBox.
        /// </summary>

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the Favourite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }
            set
            {
                this.isFavourite = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the empty message.
        /// </summary>

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public int? CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }
            set
            {
                this.cartItemCount = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that will be executed when the Favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Share button is clicked.
        /// </summary>
        public Command ShareCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the size button is clicked.
        /// </summary>
        public Command VariantCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when cart button is clicked.
        /// </summary>
        public Command CardItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Show All button is clicked.
        /// </summary>
        public Command LoadMoreCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>

        /// <summary>
        /// Invoked when the Cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddToCartClicked(object obj)
        {
            this.cartItemCount = this.cartItemCount ?? 0;
            this.CartItemCount += 1;
            Order_Detail order_Detail = new Order_Detail(App.CurrentOrder.Id, ProductDetail, 1);
            App.CurrentCart.Add(order_Detail);
            // Do something
        }

        /// <summary>
        /// Invoked when the Share button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ShareClicked(object obj)
        {
            // Do something.
        }

        /// <summary>
        /// Invoked when the variant button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VariantClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ItemSelected(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when cart icon button is clicked.
        /// </summary>
        /// <param name="obj"></param>
        private async void CartClicked(object obj)
        {
            // Do something
            await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
        }

        /// <summary>
        /// Invoked when Load more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoadMoreClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
