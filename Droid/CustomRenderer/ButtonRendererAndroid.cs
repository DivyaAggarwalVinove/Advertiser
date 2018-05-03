using Advertiser.CustomControl;
using Advertiser.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(ButtonRendererAndroid))]
namespace Advertiser.Droid
{
    public class ButtonRendererAndroid : ButtonRenderer
    {
        public ButtonRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.custom_button_style);
                Control.TextAlignment = Android.Views.TextAlignment.Center;
            }
        }
    }
}