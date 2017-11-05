using DemoInsta.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(LabelFix))]
namespace DemoInsta.Droid.CustomRenderers
{
    class LabelFix : LabelRenderer
    {
        public override void ChildDrawableStateChanged(Android.Views.View child)
        {
            base.ChildDrawableStateChanged(child);
            Control.Text = Control.Text;
        }
    }
}