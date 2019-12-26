using XamarinShoppingApp.ViewModels.Detail;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.Models;

namespace XamarinShoppingApp.Views.Detail
{
    /// <summary>
    /// The Detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailPage" /> class.
        /// </summary>
        public DetailPage(Product selectedProduct)
        {
            InitializeComponent();
            this.BindingContext = new DetailPageViewModel(selectedProduct);
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);

        //    if (width > height)
        //    {
        //        Rotator.ItemTemplate = (DataTemplate)this.Resources["LandscapeTemplate"];
        //    }
        //    else
        //    {
        //        Rotator.ItemTemplate = (DataTemplate)this.Resources["PortraitTemplate"];
        //    }
        //}
    }
}