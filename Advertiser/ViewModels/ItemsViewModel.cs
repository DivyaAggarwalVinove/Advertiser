using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Advertiser
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        //public stri<Item> item;
        //public ObservableCollection<Item> Items
        //{
        //    get { return item; }
        //    set { SetProperty(ref item, value); }
        //}

        //private ObservableCollection<SiteListData> _siteListData;
        //public ObservableCollection<Item> ItemsData
        //{
        //    get
        //    {
        //        return Items;
        //        //IEnumerable<UserInfo> userInfo = EqmsDatabase.GetInstance().GetUserInfo();
        //        //IList<UserInfo> userInfoList = userInfo.ToList();
        //        //if (userInfo.Count() > 0)
        //        //    return new ObservableCollection<SiteListData>(EqmsDatabase.GetInstance().GetSitesInfo(userInfoList[0].userID));
        //        //else
        //        //    //return null;
        //    }

        //    set { SetProperty(ref Items, value, "Items"); OnPropertyChanged("Items"); }
        //}

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    item.ImageUri = new UriImageSource { Uri = new Uri(item.ImageIcon) };
                    item.color = "#FFFFFF";
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
