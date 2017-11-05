using DemoInsta.Components;
using FFImageLoading.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Templates;
using Xamarin.Forms;

namespace DemoInsta.Models
{
    public class PostListModel
    {
        static PostListModel instance;
        ListView PostList;
        List<Post> AllPosts;
        ObservableCollection<Post> PostsItemSource;
        List<CachedImage> Animaions = new List<CachedImage>();
        public PostState ExpectedState = PostState.Unliked;
        EmptyListViewMessage EmptyMessage;

        PostListModel(ListView AListView, EmptyListViewMessage _EmptyMessage)
        {
            PostList = AListView;
            EmptyMessage = _EmptyMessage;
            InitTemplateData();
        }

        public static PostListModel Instance(ListView AListView, EmptyListViewMessage EmptyMessage)
        {
            if (instance == null)
            {
                instance = new PostListModel(AListView, EmptyMessage);
            }
            return instance;
        }

        public static void AddPost(Post NewPost)
        {
            instance.AllPosts.Add(NewPost);
        }

        public static void Filter()
        {
            instance.ApplyItemSource(new ObservableCollection<Post>(instance.AllPosts));
        }

        void InitTemplateData()
        {
            List<InstaFormsUser> Users = TemplateData.Users;
            List<Location> Locations = TemplateData.Locations;
            AllPosts = Templates.TemplateData.GetTemplatePosts(Users, Locations);
            PopulateFilterPreferences(Locations, Users);
            ApplyItemSource(new ObservableCollection<Post>(AllPosts));
        }

        void PopulateFilterPreferences(List<Location> Locations, List<InstaFormsUser> Users)
        {
            if (TemplateData.HasTemplateDataBeenInitialised() == false)
            {
                FilterPreferences.Locations = new Dictionary<IMultiSelectModel, bool>();
                for (int i = 0; i < Locations.Count; i++)
                {
                    FilterPreferences.Locations.Add(Locations[i], true);
                }

                FilterPreferences.ActiveUsers = new Dictionary<IMultiSelectModel, bool>();
                for (int i = 0; i < Users.Count; i++)
                {
                    FilterPreferences.ActiveUsers.Add(Users[i], true);
                }
            }
        }

        public void ApplyItemSource(ObservableCollection<Post> ItemSource)
        {
            PostsItemSource = ItemSource;
            FilterItemSource();
            PostList.ItemsSource = PostsItemSource;
        }

        void FilterItemSource()
        {
            foreach (Post APost in AllPosts)
            {
                if ((IsPostStateValid(APost) && IsPostDateValid(APost) && IsPostLocationValid(APost) && IsUserValid(APost)) == false)
                {
                    if (PostsItemSource.Contains(APost)) // Remove if already there
                        PostsItemSource.Remove(APost);
                }
                else
                {
                    if (PostsItemSource.Contains(APost) == false) // Add if not there
                        PostsItemSource.Add(APost);
                }
            }

            EmptyListViewCheck();
        }

        void EmptyListViewCheck()
        {
            EmptyMessage.ChangeState(PostsItemSource.Count == 0);
        }

        bool IsPostDateValid(Post APost)
        {
            return (FilterPreferences.Date == null || APost.PostDate.DayOfYear == FilterPreferences.Date.Value.DayOfYear);
        }

        bool IsPostLocationValid(Post APost)
        {
            return FilterPreferences.Locations[APost.PostLocation];
        }

        bool IsUserValid(Post APost)
        {
            return FilterPreferences.ActiveUsers[APost.User];
        }

        bool IsPostStateValid(Post APost)
        {
            if (ExpectedState == PostState.Unliked) // The search page should show both liked and unliked
            {
                return true;
            }
            else
            {
                return APost.State == ExpectedState;
            }
        }

        public void CellSelected()
        {
            PostList.SelectedItem = null;
        }

        public void PostActionFromGrid(object TheGrid)
        {
            Grid CellGrid = (Grid)TheGrid;
            ViewCell Cell = (ViewCell)(CellGrid).Parent;
            Post ThePost = (Post)Cell.BindingContext;
            PostAction(ThePost);
            CachedImage LikeIcon = CellGrid.FindByName<CachedImage>("LikeIcon");
            Task.Run(() => AnimatePostAction(LikeIcon));
        }

        public void PostActionFromButton(object TheButton)
        {
            CachedImage LikeIcon = (CachedImage)TheButton;
            StackLayout ButtonContainer = (StackLayout)(LikeIcon).Parent;
            Grid TheGrid = (Grid)ButtonContainer.Parent;
            PostActionFromGrid(TheGrid);
        }

        PostState GetNewState(PostState OldState)
        {
            switch (OldState)
            {
                case PostState.Unliked:
                    return PostState.Liked;
                default:
                    return PostState.Unliked;
            }
        }

        public void PostAction(Post APost)
        {
            APost.ObservableStateChange(GetNewState(APost.State));
        }

        async void AnimatePostAction(CachedImage LikeIcon)
        {
            if (Animaions.Contains(LikeIcon) == false)
            {
                Animaions.Add(LikeIcon);
                await LikeIcon.ScaleTo(1.2, 100);
                await LikeIcon.ScaleTo(1, 100);
                Animaions.Remove(LikeIcon);
            }
        }

        public bool ChangeState(PostState NewState)
        {
            if (NewState != ExpectedState)
            {
                ExpectedState = NewState;
                FilterItemSource();
                ScrollToTop(false);
                return true;
            }
            return false;
        }

        public void ScrollToTop(bool Animated)
        {
            if(PostsItemSource.Count > 0)
            {
                PostList.ScrollTo(PostsItemSource[0], ScrollToPosition.Start, Animated);
            }
        }
    }
}