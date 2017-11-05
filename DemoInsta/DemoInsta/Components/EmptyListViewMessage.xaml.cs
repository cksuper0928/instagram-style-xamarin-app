using Xamarin.Forms;

namespace DemoInsta.Components
{
    public partial class EmptyListViewMessage : StackLayout
    {
        public EmptyListViewMessage()
        {
            InitializeComponent();
            ChangeState(false); // Disable on start
        }

        public void ChangeState(bool State)
        {
            IsEnabled = State; 
            IsVisible = State;
        }
    }
}