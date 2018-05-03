using System;
using Xamarin.Forms;

namespace Advertiser
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetails Item { get; set; }
        public ItemDetailViewModel(ItemDetails item = null)
        {
            Title = item.Title;
            item.ImageUri = new UriImageSource { Uri = new Uri(item.ImageIcon) };
            Item = item;
        }
    }
}
