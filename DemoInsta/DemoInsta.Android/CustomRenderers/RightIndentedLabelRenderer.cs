using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DemoInsta;

[assembly: ExportRenderer(typeof(RightIndentedLabel), typeof(RightIndentedLabelRenderer))]
namespace Mobile.Droid.Renderers
{
    class RightIndentedLabelRenderer : LabelRenderer
    {
        public override void ChildDrawableStateChanged(Android.Views.View child)
        {
            base.ChildDrawableStateChanged(child);
            Control.Text = Control.Text;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Text = Control.Text;
                Control.SetPadding(0, 0, 50, 0);
            }
        }
    }
}