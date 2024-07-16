using BasicFacebookFeatures.Models;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BasicFacebookFeatures.ControllersFacade
{
    public class Controllers
    {
        private IControllers m_PhotosController = null;
        private IControllers m_PostController = null;
        private IControllers m_PageController = null;
        private IControllers m_ProfileController = null;
        private IControllers m_FriendController = null;
        private IControllers m_StatusController = null;
        private User m_LoggedInUser = null;
        private System.Windows.Forms.ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public Controllers(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, System.Windows.Forms.ProgressBar i_ProgressBar)
        {
            m_LoggedInUser = i_LoggedInUser;
            m_SearchableListBox = i_SearchableListBox;
            m_ProgressBar = i_ProgressBar;
            new Thread(fetchPhotos).Start();
            new Thread(fetchPosts).Start();
            new Thread(fetchPages).Start();
            new Thread(fetchFriends).Start();
            new Thread(fetchStatuses).Start();
        }

        private void fetchPhotos()
        {
            try
            {
                m_PhotosController = new PhotosController(m_LoggedInUser.Albums, m_SearchableListBox, m_ProgressBar);
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }
        }

        private void fetchPosts()
        {
            m_PostController = new PostController(m_LoggedInUser.Posts, m_SearchableListBox, m_ProgressBar);
        }
        
        private void fetchPages()
        {
            m_PageController = new PageController(m_LoggedInUser.LikedPages, m_SearchableListBox, m_ProgressBar);
        }
        
        private void fetchFriends()
        {
            m_FriendController = new FriendController(m_LoggedInUser.Friends, m_SearchableListBox, m_ProgressBar);
        }

        private void fetchStatuses()
        {
            m_StatusController = new StatusController(m_LoggedInUser.Statuses, m_SearchableListBox, m_ProgressBar);
        }

        public object GetController(object i_ControllerType)
        {
            object controller = null;

            switch (i_ControllerType)
            {
                case Album album:
                    controller = m_PhotosController;
                    break;
                case Post post:
                    controller = m_PostController;
                    break;
                case FacebookWrapper.ObjectModel.Page page:
                    controller = m_PageController;
                    break;
                case User user:
                    controller = m_FriendController;
                    break;
                case FacebookWrapper.ObjectModel.Status status:
                    controller = m_StatusController;
                    break;
                default:
                    break;
            }

            return controller;
        }

        public void ShowSelectedFriend(object i_User)
        {
            m_FriendController.ShowSelectedItem(i_User);
        }

        public void ShowSelectedPage(object i_Page)
        {
            m_PageController.ShowSelectedItem(i_Page);
        }

        public void ShowSelectedAlbum(object i_Album)
        {
            m_PhotosController.ShowSelectedItem(i_Album);
        }

        public void ShowSelectedPost(object i_Post)
        {
            m_PostController.ShowSelectedItem(i_Post);
        }

        public void ShowSelectedStatus(object i_Status)
        {
            m_StatusController.ShowSelectedItem(i_Status);
        }

        public void ShowPhotos()
        {
            try
            {
                m_PhotosController?.LoadData();
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }
        }

        public void ShowPosts()
        {
            m_PostController.LoadData();
        }

        public void ShowPages()
        {
            m_PageController.LoadData();
        }

        public void ShowFriends()
        {
            m_FriendController.LoadData();
        }

        public void ShowStatuses()
        {
            m_StatusController.LoadData();
        }
    }
}
