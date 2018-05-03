using Advertiser.CustomControl;
using Advertiser.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSelectButton), typeof(CustomSelectButtonRendererAndroid))]
namespace Advertiser.Droid
{
    public class CustomSelectButtonRendererAndroid : ButtonRenderer
    {
        public CustomSelectButtonRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.custom_select_button_style);
                Control.TextAlignment = Android.Views.TextAlignment.Center;
            }
        }
    }
}