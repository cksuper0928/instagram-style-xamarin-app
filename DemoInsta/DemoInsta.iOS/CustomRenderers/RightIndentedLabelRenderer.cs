using DemoInsta;
using Mobile.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RightIndentedLabel), typeof(RightIndentedLabelRenderer))]
namespace Mobile.iOS.CustomRenderers
{
    public class RightIndentedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            if (Control == null)
            {
                SetNativeControl(new TagUiLabel(new UIEdgeInsets(0, 0, 0, 10)));
            }
            base.OnElementChanged(e);
        }
    }
}