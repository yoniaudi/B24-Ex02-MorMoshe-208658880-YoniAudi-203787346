using BasicFacebookFeatures.Enums;
using BasicFacebookFeatures.Models;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Reflection;
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
            m_Controllers = new Dictionary<eControllerType, IController>()
            {
                {eControllerType.Photo, null },
                {eControllerType.Post, null },
                {eControllerType.Page, null },
                {eControllerType.Friend, null },
                {eControllerType.Status, null }
            };
            m_LoggedInUser = i_LoggedInUser;
            m_SearchableListBox = i_SearchableListBox;
            m_ProgressBar = i_ProgressBar;
            initializeProgressBar();
            startThread(() => fetchData(eControllerType.Photo));
            startThread(() => fetchData(eControllerType.Post));
            startThread(() => fetchData(eControllerType.Page));
            startThread(() => fetchData(eControllerType.Friend));
            startThread(() => fetchData(eControllerType.Status));
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
                Type controllerType = getControllerType(i_ControllerType);

                if (controllerType != null)
                {
                    ConstructorInfo constructorInfo = controllerType.GetConstructor(new Type[] { typeof(User), typeof(SearchableListBoxController), typeof(ProgressBar) });

                    if (constructorInfo != null)
                    {
                        object controllerInstance = constructorInfo.Invoke(new object[] { m_LoggedInUser, m_SearchableListBox, m_ProgressBar });
                        
                        m_Controllers[i_ControllerType] = controllerInstance as IController;
                    }
                    else
                    {
                        throw new Exception("Constructor not found.");
                    }
                }
                else
                {
                    throw new Exception("Controller type not found.");
                }
            }
            catch (Exception ex)
            {
                string exceptionMsg = string.Format("Getting {0} is not supported by Meta anymore.{1}Press ok to continue.{1}Error: {2}",
                    i_ControllerType.ToString(), Environment.NewLine, ex.Message);

                MessageBox.Show(exceptionMsg);
            }
        }

        private Type getControllerType(eControllerType i_ControllerType)
        {
            Type controllerType = null;

            switch (i_ControllerType)
            {
                case eControllerType.Photo:
                    controllerType = typeof(PhotosController);
                    break;
                case eControllerType.Post:
                    controllerType = typeof(PostController);
                    break;
                case eControllerType.Page:
                    controllerType = typeof(PageController);
                    break;
                case eControllerType.Friend:
                    controllerType = typeof(FriendController);
                    break;
                case eControllerType.Status:
                    controllerType = typeof(StatusController);
                    break;
                default:
                    break;
            }

            return controllerType;
        }

        public object GetController(eControllerType i_ControllerType)
        {
            lock (r_LockObject)
            {
                return m_Controllers[i_ControllerType];
            }
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