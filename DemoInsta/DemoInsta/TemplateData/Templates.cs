using DemoInsta.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Templates
{
    public static class TemplateData
    {
        public static bool HasTemplateDataBeenInitialised()
        {
            return Application.Current.Properties.ContainsKey("initialised");
        }

        public static List<Post> GetTemplatePosts(List<InstaFormsUser> Users, List<Location> Locations) // Creates 6 posts with the 4 users
        {
            List<Post> Posts = new List<Post>
            {
                new Post
                {
                    User = Users[0],
                    PostDate = DateTime.Now.AddDays(-5),
                    PostLocation = Locations[0],
                    Title = "Enjoying a day out at the lake",
                    Picture = ImageSource.FromFile("image1.jpg")
                },

                new Post
                {
                    User = Users[1],
                    PostDate = DateTime.Now.AddDays(-4),
                    PostLocation = Locations[1],
                    Title = "I love abstract art like this",
                    Picture = ImageSource.FromFile("image2.jpg")
                },

                new Post
                {
                    User = Users[2],
                    PostDate = DateTime.Now.AddDays(-3),
                    PostLocation = Locations[2],
                    Title = "The west coast is so beautiful!",
                    Picture = ImageSource.FromFile("image3.jpg")
                },

                new Post
                {
                    User = Users[3],
                    PostDate = DateTime.Now.AddDays(-2),
                    PostLocation = Locations[3],
                    Title = "Just a cool bridge",
                    Picture = ImageSource.FromFile("image4.jpg")
                },

                new Post
                {
                    User = Users[0],
                    PostDate = DateTime.Now.AddDays(-1),
                    PostLocation = Locations[0],
                    Title = "About to dig into this burger",
                    Picture = ImageSource.FromFile("image5.jpg")
                },

                new Post
                {
                    User = Users[1],
                    PostDate = DateTime.Now,
                    PostLocation = Locations[1],
                    Title = "Back in the office :)",
                    Picture = ImageSource.FromFile("image6.jpg")
                }
            };

            return Posts;
        }

        public static List<Location> Locations = new List<Location>()
        {
            new Location
            {
                Name = "Los Angeles",
            },

                new Location
                {
                    Name = "New York",
                },

                new Location
                {
                    Name = "Paris",
                },

                new Location
                {
                    Name = "London",
                },
        };

        public static List<InstaFormsUser> Users = new List<InstaFormsUser>() // Creates 4 users
        {
                new InstaFormsUser
                {
                    FirstName = "James",
                    LastName = "Porter",
                    ProfilePicture = ImageSource.FromFile("user1.png")
                },

                new InstaFormsUser
                {
                    FirstName = "Mary",
                    LastName = "Jones",
                    ProfilePicture = ImageSource.FromFile("user2.png")
                },

                new InstaFormsUser
                {
                    FirstName = "Jim",
                    LastName = "Lampert",
                    ProfilePicture = ImageSource.FromFile("user3.png")
                },

                new InstaFormsUser
                {
                    FirstName = "Anna",
                    LastName = "Bower",
                    ProfilePicture = ImageSource.FromFile("user4.png")
                }
        };
    }
}