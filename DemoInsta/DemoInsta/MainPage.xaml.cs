using DemoInsta.Models;
using DemoInsta.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoInsta
{
    public partial class MainPage : ContentPage
    {
        PostListModel PostListSingleton;
        private readonly NewImageHelper NewImage;
        public MainPage()
        {
            InitializeComponent();
            NewImage = new NewImageHelper();
            PostListSingleton = PostListModel.Instance(PostList, EmptyMessage);
            SettingsSlide.InitialiseSettingsElements();
            SettingsSlide.TranslationX -= Measurements.VirtualScreenWidth;
        }

        private void CellSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PostListSingleton.CellSelected();
        }

        private void PostDoubleTapped(object sender, System.EventArgs e)
        {
            PostListSingleton.PostActionFromGrid(sender);
        }

        private void LikeButtonTapped(object sender, System.EventArgs e)
        {
            PostListSingleton.PostActionFromButton(sender);
        }

        private void OpenSettingsSlide(object sender, System.EventArgs e)
        {
            SettingsSlideBack.IsEnabled = true;
            SettingsSlideBack.IsVisible = true;
            SettingsSlide.TranslateTo(0, 0, 300, Easing.CubicInOut);
        }

        private void CloseSettingsSlide(object sender, System.EventArgs e)
        {
            SettingsSlideBack.IsEnabled = false;
            SettingsSlideBack.IsVisible = false;
            SettingsSlide.TranslateTo(-Measurements.VirtualScreenWidth, 0, 300, Easing.CubicInOut);
        }

        void ChangeTabBarIcon(bool Result)
        {
            if (Result)
            {
                if (PostListSingleton.ExpectedState == PostState.Unliked)
                {
                    UpdateTabBar(SearchPageImg, LikedPageImg);
                }
                else
                {
                    UpdateTabBar(LikedPageImg, SearchPageImg);
                }
            }
        }

        private void ToSearchPage(object sender, System.EventArgs e)
        {
            bool Result = PostListSingleton.ChangeState(PostState.Unliked);
            ChangeTabBarIcon(Result);
        }

        private void ToLikedPage(object sender, System.EventArgs e)
        {
            bool Result = PostListSingleton.ChangeState(PostState.Liked);
            ChangeTabBarIcon(Result);
        }

        async Task AddImagePage(object sender, System.EventArgs e)
        {
            string Type = await DisplayActionSheet("Create a new post", "Cancel", null, "Take Photo", "Choose from gallery");

            string ID = await NewImage.PromptGetImage(Type);

            if (ID == null)
            {
                return;
            }
            else
            {
                await Navigation.PushModalAsync(new AddImagePage(ID));
            }
        }

        void UpdateTabBar(Image Active, Image Inactive)
        {
            Active.Opacity = 1;
            Inactive.Opacity = 0.4;
        }

        private void ScrollToTop(object sender, System.EventArgs e)
        {
            PostListSingleton.ScrollToTop(true);
        }
    }
}