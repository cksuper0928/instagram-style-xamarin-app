using UIKit;

namespace DemoInsta.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            InitDeviceValues();

            UIApplication.Main(args, null, "AppDelegate");
        }

        static void InitDeviceValues()
        {
            Measurements.AvailableVirtualScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            Measurements.VirtualScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            Measurements.VirtualScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            Measurements.HeightInPixels = (int)((double)Measurements.VirtualScreenHeight * UIScreen.MainScreen.NativeScale);
            Measurements.WidthInPixels = (int)((double)Measurements.VirtualScreenWidth * UIScreen.MainScreen.NativeScale);
            Measurements.InchInVirtualUnits = 163; // An inch in xamarin forms for iOS only
            Measurements.AvailableVirtualScreenHeight = Measurements.VirtualScreenHeight - 20;

            Measurements.InitValues();
        }
    }
}