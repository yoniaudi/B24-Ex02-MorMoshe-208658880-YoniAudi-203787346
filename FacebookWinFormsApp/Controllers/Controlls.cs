using BasicFacebookFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Controllers
{
    public class Controlls
    {
        public IControllers FriendController { get; set; }
        public IControllers PageController { get; set; }
        public IControllers PhotosController { get; set; }
        public IControllers PostController { get; set; }
        public IControllers ProfileController { get; set; }
        public IControllers StatusController { get; set; }
     
        public Controlls()
        {
            FriendController = new FriendController();
            PageController = new PageController();
            PhotosController = new PhotosController();
            PostController = new PostController();
            StatusController = new StatusController();
        }

        public void ShowSelectedFriend(object i_Object)
        {
            FriendController.Show(i_Object);
        }

        public void ShowSelectedPage(object i_Object)
        {
            PageController.Show(i_Object);
        }

        public void ShowSelectedAlbum(object i_Object)
        {
            PhotosController.Show(i_Object);
        }

        public void ShowSelectedPost(object i_Object)
        {
            PostController.Show(i_Object);
        }

        public void ShowSelectedStatus(object i_Object)
        {
            StatusController.Show(i_Object);
        }
    }
}
