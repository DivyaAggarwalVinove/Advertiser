using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Advertiser
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            List<Item> previousItem = (viewModel.Items.Where(x=>(x.color== "#ecf8ff"))).ToList<Item>();
            
            if (previousItem != null && previousItem.Count != 0)
            {
                int selectedItemIndex = viewModel.Items.IndexOf(previousItem.ElementAt(0));
                previousItem.ElementAt(0).color = "#FFFFFF";
                viewModel.Items.ElementAt(selectedItemIndex).color = "#FFFFFF";
            }

            int tobeSelectedItemIndex = viewModel.Items.IndexOf(item);
            viewModel.Items.ElementAt(tobeSelectedItemIndex).color = "#ecf8ff";


            var itemDetails = await DependencyService.Get<CloudDataStore>().GetItemAsync(item.Id);

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(itemDetails)) { Title = "Ad Detail"});

            previousItem = (viewModel.Items.Where(x => (x.color == "#ecf8ff"))).ToList<Item>();

            if (previousItem != null && previousItem.Count != 0)
            {
                int selectedItemIndex = viewModel.Items.IndexOf(previousItem.ElementAt(0));
                previousItem.ElementAt(0).color = "#FFFFFF";
                viewModel.Items.ElementAt(selectedItemIndex).color = "#FFFFFF";
            }
        }

        void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                string searchText = entrySearch.Text;
                //string searchText = "Admin";
                if(!string.IsNullOrEmpty(searchText))
                {
                    ItemsListView.ItemsSource =  viewModel.Items.Where(x => x.Title.Contains(searchText));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void OnTextChanged(object sender, EventArgs args)
        {
            try
            {
                string searchText = entrySearch.Text;
                //string searchText = "Admin";
                if (string.IsNullOrEmpty(searchText))
                {
                    ItemsListView.ItemsSource = viewModel.Items;
                }
                else
                {
                    ItemsListView.ItemsSource = viewModel.Items.Where(x => x.Title.ToUpper().Contains(searchText.ToUpper()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new NewItemPage());
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
