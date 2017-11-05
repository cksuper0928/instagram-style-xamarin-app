using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoInsta.Models
{
    class NewImageHelper
    {
        public static Dictionary<string, ImageSource> Images = new Dictionary<string, ImageSource>();

        public async Task<string> PromptGetImage(string Type)
        {
            if (Type.Equals("Take Photo"))
            {
                return await TakePhoto();
            }
            else
            {
                return await ChooseFromGallery();
            }
        }

        async Task<string> TakePhoto()
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = "test.jpeg",
            });


            if (file != null)
            {
                string ID = Guid.NewGuid().ToString();
                Images.Add(ID, ImageSource.FromStream(() => file.GetStream()));
                return ID;
            }
            else
            {
                return null;
            }
        }

        async Task<string> ChooseFromGallery()
        {
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });


            if (file != null)
            {
                string ID = Guid.NewGuid().ToString();
                Images.Add(ID, ImageSource.FromStream(() => file.GetStream()));
                return ID;
            }
            else
            {
                return null;
            }
        }
    }
}
