using Advertiser.CustomControl;
using Advertiser.Droid;
using Android.Content;
using Android.Content.Res;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRendererAndroid))]
namespace Advertiser.Droid
{
    public class CustomLabelRendererAndroid : LabelRenderer
    {
        public CustomLabelRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetMaxLines(3);
                Control.SetTextColor(ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#161616")));
                //Control.SetBackgroundResource(Resource.Drawable.custom_entry_style);
                //Control.TextAlignment = Android.Views.TextAlignment.Center;
            }
        }
    }
}