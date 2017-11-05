using DemoInsta.Models;
using System;
using System.Threading.Tasks;
using Templates;
using Xamarin.Forms;

namespace DemoInsta.ViewModels
{
    public partial class AddImagePage : ContentPage
    {
        public AddImagePage(string ID)
        {
            InitializeComponent();
            NewImg.Source = NewImageHelper.Images[ID];
            Setup();
        }

        private async void ReturnHome(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void Setup()
        {
            foreach (InstaFormsUser Item in TemplateData.Users)
            {
                UserPicker.Items.Add(Item.Name);
            }
            foreach (Location Item in TemplateData.Locations)
            {
                LocationPicker.Items.Add(Item.Name);
            }
            UserPicker.SelectedIndex = 0;
            LocationPicker.SelectedIndex = 0;
        }

        InstaFormsUser GetUser(string Name)
        {
            foreach (InstaFormsUser Item in TemplateData.Users)
            {
                if (Item.Name.Equals(Name))
                {
                    return Item;
                }
            }
            return null;
        }

        Location GetLocation(string Name)
        {
            foreach (Location Item in TemplateData.Locations)
            {
                if (Item.Name.Equals(Name))
                {
                    return Item;
                }
            }
            return null;
        }

        async Task Save(object sender, EventArgs e)
        {
            Post NewPost = new Post()
            {
                Picture = NewImg.Source,
                PostDate = DateTime.Now,
                PostLocation = GetLocation((string)LocationPicker.SelectedItem),
                User = GetUser((string)UserPicker.SelectedItem),
                Title = PostTitle.Text
            };

            PostListModel.AddPost(NewPost);
            PostListModel.Filter();

            if (Navigation.ModalStack.Count == 1)
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}