using Advertiser.CustomControl;
using Advertiser.Droid;
using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDiscountButton), typeof(CustomDiscountButtonRendererAndroid))]
namespace Advertiser.Droid
{
    public class CustomDiscountButtonRendererAndroid : ButtonRenderer
    {
        public CustomDiscountButtonRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.custom_discount_button_style);
                Control.TextAlignment = Android.Views.TextAlignment.Center;//Context.ApplicationContext.Assets;
                var font = Typeface.CreateFromAsset(Context.ApplicationContext.Assets, "Montserrat-Bold.ttf");
                Control.Typeface = font;
            }
        }
    }
}