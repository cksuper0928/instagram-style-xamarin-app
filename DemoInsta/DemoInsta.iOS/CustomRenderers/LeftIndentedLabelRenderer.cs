using DemoInsta;
using Mobile.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LeftIndentedLabel), typeof(LeftIndentedLabelRenderer))]
namespace Mobile.iOS.CustomRenderers
{
    class LeftIndentedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            if (Control == null)
            {
                SetNativeControl(new TagUiLabel(new UIEdgeInsets(0, 10, 0, 0)));
            }
            base.OnElementChanged(e);
        }
    }
}