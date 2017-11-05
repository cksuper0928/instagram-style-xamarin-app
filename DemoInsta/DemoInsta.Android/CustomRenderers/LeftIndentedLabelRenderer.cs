using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DemoInsta;

[assembly: ExportRenderer(typeof(LeftIndentedLabel), typeof(LeftIndentedLabelRenderer))]
namespace Mobile.Droid.Renderers
{
    class LeftIndentedLabelRenderer : LabelRenderer
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
                Control.SetPadding(50, 0, 0, 0);
            }
        }
    }
}