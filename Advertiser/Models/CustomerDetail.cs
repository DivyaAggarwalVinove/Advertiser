using Newtonsoft.Json;
using Xamarin.Forms;

namespace Advertiser
{
    public class CustomerDetail
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mobile")]
        public string Phone { get; set; }

        public UriImageSource ImageUri { get; set; }
    }
}
