namespace DemoInsta
{
    public static class Measurements
    {
        public static int VirtualScreenHeight;
        public static int AvailableVirtualScreenHeight; // Virtual screen height minus the tab bar
        public static int VirtualScreenWidth;
        public static int HeightInPixels;
        public static int WidthInPixels;
        public static double InchInVirtualUnits; // Inch in Xamarin units. ~ 95% accuracy, due to numerous conversions between various units and platforms

        public static double ProportionalViewSize;
        public static double HalfScreenHeight;

        public static void InitValues()
        {
            ProportionalViewSize = InchInVirtualUnits * 0.33;
            HalfScreenHeight = VirtualScreenHeight / 2;
        }

    }
}
