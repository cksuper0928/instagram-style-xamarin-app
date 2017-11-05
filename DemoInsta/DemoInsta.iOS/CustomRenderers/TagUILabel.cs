using UIKit;

namespace Mobile.iOS.CustomRenderers
{
    public class TagUiLabel : UILabel
    {
        private UIEdgeInsets EdgeInsets { get; set; }

        public TagUiLabel(UIEdgeInsets Padding)
        {
            EdgeInsets = Padding;
        }
        public override void DrawText(CoreGraphics.CGRect rect)
        {
            base.DrawText(EdgeInsets.InsetRect(rect));
        }
    }
}