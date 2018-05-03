using Xamarin.Forms;
using Advertiser.CustomControl;

namespace Advertiser
{
    public partial class App : Application
    {
        //public static bool UseMockDataStore = false;
        public static string BackendUrl = "http://advertiser.n1.iworklab.com/public";
       // http://advertiser.n1.iworklab.com/public/api/get-details/
        public App()
        {
            InitializeComponent();

            DependencyService.Register<CloudDataStore>();
            MainPage = new NavigationPage(new ItemsPage() { Title = "Ad List" });
            //MainPage = new CustomNavigationPage(new ItemsPage() { Title = "Ad List" });
        }
    }
}
