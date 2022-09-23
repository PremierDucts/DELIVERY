using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using DeliveryMobile.CustomControls;
using DeliveryMobile.Droid.CustomControls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace DeliveryMobile.Droid.CustomControls
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}