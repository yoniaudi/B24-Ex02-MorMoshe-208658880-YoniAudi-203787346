using BasicFacebookFeatures.Models;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
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
        private SearchableListBoxController m_SearchableListBox = null;

        public Controllers(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, System.Windows.Forms.ProgressBar i_ProgressBar)
        {
            m_PostController = new PostController(i_LoggedInUser.Posts, i_SearchableListBox, i_ProgressBar);
            m_PageController = new PageController(i_LoggedInUser.LikedPages, i_SearchableListBox, i_ProgressBar);
            m_FriendController = new FriendController(i_LoggedInUser.Friends, i_SearchableListBox, i_ProgressBar);
            m_StatusController = new StatusController(i_LoggedInUser.Statuses, i_SearchableListBox, i_ProgressBar);
            m_SearchableListBox = i_SearchableListBox;
            
            try
            {
                m_PhotosController = new PhotosController(i_LoggedInUser.Albums, i_SearchableListBox, i_ProgressBar);
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }
        }

        public object GetController(object i_ControllerType)
        {
            switch (i_ControllerType)
            {
                case Album album:
                    return m_PhotosController;
                case Post post:
                    return m_PostController;
                case FacebookWrapper.ObjectModel.Page page:
                    return m_PageController;
                case User user:
                    return m_FriendController;
                case FacebookWrapper.ObjectModel.Status status:
                    return m_StatusController;
                default:
                    break;
            }

            return null;
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
                m_PhotosController?.ShowController();
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
            m_PostController.ShowController();
        }

        public void ShowPages()
        {
            m_PageController.ShowController();
        }

        public void ShowFriends()
        {
            m_FriendController.ShowController();
        }

        public void ShowStatuses()
        {
            m_StatusController.ShowController();
        }
    }
}
