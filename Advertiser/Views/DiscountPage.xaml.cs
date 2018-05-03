using System;
using System.Diagnostics;
using System.Net.Mail;
using Xamarin.Forms;

namespace Advertiser
{
    public partial class DiscountPage : ContentPage
    {
        public ItemDetails details { get; set; }
        public int advertiseId = 0;
        public UriImageSource ImageUri;
        public DiscountPage()
        {
            InitializeComponent();
        }

        public DiscountPage(ItemDetails itemDetails)
        {
            InitializeComponent();

            /*Item = new Item
            {
                Title = "Item name",
                Description = "This is an item description."
            };*/
            details = itemDetails;
            BindingContext = this;
        }

        async void OnSubmit(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryPhone.Text))
            {
                await DisplayAlert("Warning", "Please enter Phone Number", "Ok");
            }
            else if (string.IsNullOrEmpty(entryName.Text))
            {
                await DisplayAlert("Warning", "Please enter Name", "Ok");
            }
            else if (string.IsNullOrEmpty(entryEmail.Text))
            {
                await DisplayAlert("Warning", "Please enter Email", "Ok");
            }
            else if (entryPhone.Text.Length < 10)
            {
                await DisplayAlert("Warning", "Phone Number should be of at least 10 digits.", "Ok");
            }
            else
            {
                MailAddress addr = null;
                try
                {
                    addr = new MailAddress(entryEmail.Text);

                    if (addr.Address != entryEmail.Text)
                    {
                        await DisplayAlert("Warning", "Email ID is not valid.", "Ok");
                    }
                    else
                    {
                        bool response = await DisplayAlert("Confirmation", "Do you want to submit?", "Yes", "No");

                        if (response)
                        {
                            CustomerDetail customerDetail = new CustomerDetail();
                            customerDetail.Phone = entryPhone.Text;
                            customerDetail.Name = entryName.Text;
                            customerDetail.Email = entryEmail.Text;
                            bool result = await DependencyService.Get<CloudDataStore>().SendInformation(customerDetail, advertiseId);

                            if (result)
                                await Navigation.PopToRootAsync();
                            else
                            {
                                await DisplayAlert("Warning", "Please try again!", "Ok");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.GetType().ToString().Equals("System.FormatException"))
                        await DisplayAlert("Warning", "Email ID is not valid.", "Ok");
                }
            }
        }

        /*async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }*/
    }
}