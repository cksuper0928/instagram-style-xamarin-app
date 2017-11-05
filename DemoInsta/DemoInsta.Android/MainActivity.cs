using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Android.Content.Res;
using Android.Util;

namespace DemoInsta.Droid
{
    [Activity(Label = "DemoInsta", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CachedImageRenderer.Init();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            InitDeviceValues();
            LoadApplication(new App());
        }

        protected void InitDeviceValues()
        {
            var metrics = Resources.DisplayMetrics;

            int statusBarHeight = 0, totalHeight = 0, contentHeight = 0;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            statusBarHeight = Resources.GetDimensionPixelSize(resourceId);

            totalHeight = Resources.DisplayMetrics.HeightPixels;
            contentHeight = totalHeight - statusBarHeight;

            bool AppAlreadyInitialised = Measurements.VirtualScreenHeight != 0;

            Measurements.AvailableVirtualScreenHeight = (int)(contentHeight / metrics.Density);
            Measurements.VirtualScreenWidth = (int)(metrics.WidthPixels / metrics.Density);
            Measurements.HeightInPixels = metrics.HeightPixels;
            Measurements.WidthInPixels = metrics.WidthPixels;
            Measurements.VirtualScreenHeight = (int)(totalHeight / metrics.Density);

            int DPs = (int)TypedValue.ApplyDimension(ComplexUnitType.In, 1, metrics);
            Measurements.InchInVirtualUnits = (int)(DPs / metrics.Density);

            if (AppAlreadyInitialised == false)
            {
                Measurements.InitValues();
            }
        }
    }
}

