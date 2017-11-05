using Xamarin.Forms;

namespace DemoInsta.Models
{
    public class InstaFormsUser : IMultiSelectModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ImageSource ProfilePicture { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
