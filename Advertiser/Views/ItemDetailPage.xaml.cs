using System;

using Xamarin.Forms;

namespace Advertiser
{
    public partial class ItemDetailPage : ContentPage
    {
        //public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(ItemDetailPage), "Ad Detail"); public string HeaderText { get { return (string)GetValue(HeaderTextProperty); } }

        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var item = new ItemDetails
            {
                Title = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        void OnClaim(object sender, EventArgs eventArgs)
        {
            //var itemDetails = eventArgs as ItemDetails;
            DiscountPage discountPage = new DiscountPage(viewModel.Item) { Title = "Get Discount" };
            discountPage.advertiseId = viewModel.Item.Id;
            //discountPage.ImageUri = viewModel.Item.ImageUri;
            Navigation.PushAsync(discountPage);
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
