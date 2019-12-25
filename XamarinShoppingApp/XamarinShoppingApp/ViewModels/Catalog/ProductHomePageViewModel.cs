using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using XamarinShoppingApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System;
using XamarinShoppingApp.Views.Catalog;
using XamarinShoppingApp.Views.Cart;

namespace XamarinShoppingApp.ViewModels.Catalog
{
    /// <summary>
    /// ViewModel for home page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ProductHomePageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<CartItem> newArrivalProduts;

        private ObservableCollection<CartItem> offerProduts;

        private ObservableCollection<CartItem> recommendedProduts;

        private Command itemSelectedCommand;

        private string bannerImage;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with Xamarin.Forms Image, which displays the banner image.
        /// </summary>
        [DataMember(Name = "bannerimage")]
        public string BannerImage
        {
            get { return this.bannerImage; }
            set { this.bannerImage = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>
        [DataMember(Name = "newarrivalproducts")]
        public ObservableCollection<CartItem> NewArrivalProducts
        {
            get
            {
                return this.newArrivalProduts;
            }

            set
            {
                if (this.newArrivalProduts == value)
                {
                    return;
                }

                this.newArrivalProduts = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>
        [DataMember(Name = "offerproducts")]
        public ObservableCollection<CartItem> OfferProducts
        {
            get
            {
                return this.offerProduts;
            }

            set
            {
                if (this.offerProduts == value)
                {
                    return;
                }

                this.offerProduts = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>
        [DataMember(Name = "recommendedproducts")]
        public ObservableCollection<CartItem> RecommendedProducts
        {
            get
            {
                return this.recommendedProduts;
            }

            set
            {
                if (this.recommendedProduts == value)
                {
                    return;
                }

                this.recommendedProduts = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private async void ItemSelected(object attachedObject)
        {
            // Do something
            CartItem selected = (CartItem)(attachedObject as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            await Application.Current.MainPage.Navigation.PushAsync(new test());
        }

        #endregion
    }
}