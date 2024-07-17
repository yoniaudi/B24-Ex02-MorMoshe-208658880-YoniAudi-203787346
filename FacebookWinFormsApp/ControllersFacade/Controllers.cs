using BasicFacebookFeatures.Enums;
using BasicFacebookFeatures.Models;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;

namespace BasicFacebookFeatures.ControllersFacade
{
    public class Controllers
    {
        private Dictionary<eControllerType, IController> m_Controllers = null;
        private User m_LoggedInUser = null;
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;
        private int m_ActiveThreads = 0;
        private readonly object r_LockObject = new object();

        public Controllers(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
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

        private void fetchData(eControllerType i_ControllerType)
        {
            try
            {
                m_Controllers[i_ControllerType] = new PhotosController(m_LoggedInUser.Albums, m_SearchableListBox, m_ProgressBar);
                //m_Controllers[i_ControllerType] = new PhotosController(m_LoggedInUser.Albums, m_SearchableListBox, m_ProgressBar);
            }
            catch (Exception ex)
            {
                string exceptionMsg = string.Format("Getting {0} is not supported by Meta anymore.{1}Press ok to continue.{1}Error: {2}",
                    i_ControllerType.ToString(), Environment.NewLine, ex.Message);

                MessageBox.Show(exceptionMsg);
            }
        }

        private void fetchPhotos()
        {
            try
            {
                m_Controllers[eControllerType.Photo] = new PhotosController(m_LoggedInUser.Albums, m_SearchableListBox, m_ProgressBar);
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
            m_Controllers[eControllerType.Post] = new PostController(m_LoggedInUser.Posts, m_SearchableListBox, m_ProgressBar);
        }

        private void fetchPages()
        {
            m_Controllers[eControllerType.Page] = new PageController(m_LoggedInUser.LikedPages, m_SearchableListBox, m_ProgressBar);
        }

        private void fetchFriends()
        {
            m_Controllers[eControllerType.Friend] = new FriendController(m_LoggedInUser.Friends, m_SearchableListBox, m_ProgressBar);
        }

        private void fetchStatuses()
        {
            m_Controllers[eControllerType.Status] = new StatusController(m_LoggedInUser.Statuses, m_SearchableListBox, m_ProgressBar);
        }

        public object GetController(eControllerType i_ControllerType)
        {
            return m_Controllers[i_ControllerType];
        }

        public void LoadDataToListBox(eControllerType i_ControllerType)
        {
            try
            {
                m_Controllers[i_ControllerType]?.LoadDataToListBox();
            }
            catch (Exception ex)
            {
                string exceptionMsg = string.Format("Getting {0} is not supported by Meta anymore.{1}Press ok to continue.{1}Error: {2}",
                    i_ControllerType.ToString(), Environment.NewLine, ex.Message);

                MessageBox.Show(exceptionMsg);
            }
        }

        public void ShowSelectedItem(object i_SelectedItem)
        {
            switch (i_SelectedItem)
            {
                case Album album:
                    m_Controllers[eControllerType.Photo].ShowSelectedItem(i_SelectedItem);
                    break;
                case Post post:
                    m_Controllers[eControllerType.Post].ShowSelectedItem(i_SelectedItem);
                    break;
                case Page page:
                    m_Controllers[eControllerType.Page].ShowSelectedItem(i_SelectedItem);
                    break;
                case User user:
                    m_Controllers[eControllerType.Friend].ShowSelectedItem(i_SelectedItem);
                    break;
                case Status status:
                    m_Controllers[eControllerType.Status].ShowSelectedItem(i_SelectedItem);
                    break;
                default:
                    break;
            }
        }
    }
}