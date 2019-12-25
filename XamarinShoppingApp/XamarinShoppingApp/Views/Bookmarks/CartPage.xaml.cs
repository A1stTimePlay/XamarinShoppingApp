using XamarinShoppingApp.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.ViewModels.Cart;

namespace XamarinShoppingApp.Views.Bookmarks
{
    /// <summary>
    /// Page to show the cart list. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartPage" /> class.
        /// </summary>
        public CartPage()
        {
            InitializeComponent();
            this.BindingContext = new CartVM();
        }
    }
}