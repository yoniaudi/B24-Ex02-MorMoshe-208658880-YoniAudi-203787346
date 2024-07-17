using BasicFacebookFeatures.Models;
using FacebookWrapper.ObjectModel;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BasicFacebookFeatures.ControllersFacade
{
    public class Controllers
    {
        private IController m_PhotosController = null;
        private IController m_PostController = null;
        private IController m_PageController = null;
        private IController m_FriendController = null;
        private IController m_StatusController = null;
        private User m_LoggedInUser = null;
        private System.Windows.Forms.ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;
        private int m_ActiveThreads = 0;
        private readonly object r_LockObject = new object();

        public Controllers(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, System.Windows.Forms.ProgressBar i_ProgressBar)
        {
            m_LoggedInUser = i_LoggedInUser;
            m_SearchableListBox = i_SearchableListBox;
            m_ProgressBar = i_ProgressBar;
            initializeProgressBar();
            startThread(fetchPhotos);
            startThread(fetchPosts);
            startThread(fetchPages);
            startThread(fetchFriends);
            startThread(fetchStatuses);
        }

        private void initializeProgressBar()
        {
            m_ProgressBar.Invoke(new Action(() =>
            {
                m_ProgressBar.Visible = true;
                m_ProgressBar.Minimum = 0;
                m_ProgressBar.Value = 0;
                m_ProgressBar.Step = 1;
            }));
        }

        private void startThread(ThreadStart i_ThreadStart)
        {
            lock (r_LockObject)
            {
                m_ActiveThreads++;
            }

            new Thread(() =>
            {
                i_ThreadStart();
                threadFinished();
            }).Start();
        }

        private void threadFinished()
        {
            lock (r_LockObject)
            {
                m_ActiveThreads--;

                if (m_ActiveThreads == 0)
                {
                    m_ProgressBar.Invoke(new Action(() =>
                    {
                        m_ProgressBar.Visible = false;
                    }));
                }
            }
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
                m_PhotosController?.LoadDataToListBox();
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
            m_PostController.LoadDataToListBox();
        }

        public void ShowPages()
        {
            m_PageController.LoadDataToListBox();
        }

        public void ShowFriends()
        {
            m_FriendController.LoadDataToListBox();
        }

        public void ShowStatuses()
        {
            m_StatusController.LoadDataToListBox();
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
    }
}
