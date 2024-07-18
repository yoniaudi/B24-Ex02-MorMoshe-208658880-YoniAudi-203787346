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
        private User m_LoggedInUser = null;
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;
        private int m_ActiveThreads = 0;
        private readonly object r_LockObject = new object();
        private readonly Dictionary<eControllerType, IController> r_Controllers = null;
        private readonly Dictionary<Type, eControllerType> r_SelectedItemTypes = null;

        public Controllers(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            r_Controllers = new Dictionary<eControllerType, IController>()
            {
                { eControllerType.Photo, new PhotoController() },
                { eControllerType.Post, new PostController() },
                { eControllerType.Page, new PageController() },
                { eControllerType.Profile, new ProfileController() },
                { eControllerType.Friend, new FriendController() },
                { eControllerType.Status, new StatusController() }
            };
            r_SelectedItemTypes = new Dictionary<Type, eControllerType>()
            {
                { typeof(Album), eControllerType.Photo },
                { typeof(Post), eControllerType.Post },
                { typeof(Page), eControllerType.Page },
                { typeof(User), eControllerType.Friend },
                { typeof(Status), eControllerType.Status }
            };
            m_LoggedInUser = i_LoggedInUser;
            m_SearchableListBox = i_SearchableListBox;
            m_ProgressBar = i_ProgressBar;
            initializeProgressBar();
            launchThreads();
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

        private void launchThreads()
        {
            foreach(eControllerType controllerType in Enum.GetValues(typeof(eControllerType)))
            {
                startThread(() => fetchData(controllerType));
            }
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
                    m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Visible = false));
                }
            }
        }

        private void fetchData(eControllerType i_ControllerType)
        {
            try
            {
                Type controllerType = getControllerType(i_ControllerType);

                if (controllerType == null)
                {
                    throw new Exception("Controller type not found.");
                }
                
                ConstructorInfo constructorInfo = controllerType.GetConstructor(new Type[] { typeof(User), typeof(SearchableListBoxController), typeof(ProgressBar) });

                if (constructorInfo == null)
                {
                    throw new Exception("Constructor not found.");
                }
                    
                object controllerInstance = constructorInfo.Invoke(new object[] { m_LoggedInUser, m_SearchableListBox, m_ProgressBar });

                r_Controllers[i_ControllerType] = controllerInstance as IController;
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
            lock (r_LockObject)
            {
                return r_Controllers[i_ControllerType]?.GetType();
            }
        }

        public object GetController(eControllerType i_ControllerType)
        {
            lock (r_LockObject)
            {
                return r_Controllers[i_ControllerType];
            }
        }

        public void LoadDataToListBox(eControllerType i_ControllerType)
        {
            try
            {
                r_Controllers[i_ControllerType]?.LoadDataToListBox();
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
            if (i_SelectedItem != null)
            {
                Type selectedItemType = i_SelectedItem.GetType();
                bool isValueRetrieved = r_SelectedItemTypes.TryGetValue(selectedItemType, out eControllerType controllerType);

                if (isValueRetrieved == true)
                {
                    r_Controllers[controllerType].ShowSelectedItem(i_SelectedItem);
                }
            }
        }
    }
}