using BasicFacebookFeatures.ControllersFacade;
using BasicFacebookFeatures.Enums;
using BasicFacebookFeatures.Features.TravelBuddy;
using BasicFacebookFeatures.Features.Volunteering;
using BasicFacebookFeatures.Models;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult = null;
        private User m_LoggedInUser = null;
        private Dictionary<eControllerType, Panel> m_Panels = null;
        private Controllers m_Controllers = null;

        public FormMain()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 25;
            m_Panels = new Dictionary<eControllerType, Panel>()
            {
                { eControllerType.Photo, panelPhotos },
                { eControllerType.Post, panelPosts },
                { eControllerType.Page, panelPages },
                { eControllerType.Profile, panelProfile },
                { eControllerType.Friend, panelFriends },
                { eControllerType.Status, panelStatuses }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            checkBoxRememberMe.Checked = ApplicationSettings.Instance.AutoLogin;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (ApplicationSettings.Instance.AutoLogin == true)
            {
                autoLogin();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ApplicationSettings.Instance.AutoLogin = checkBoxRememberMe.Checked;
            ApplicationSettings.Instance.Save();
        }

        private void autoLogin()
        {
            m_LoginResult = FacebookService.Connect(ApplicationSettings.Instance.AccessToken);

            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                fetchLoggedInUser();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
                textBoxAppID.Text,
                "email",
                "public_profile",
                "user_hometown",
                "user_birthday",
                "user_age_range",
                "user_gender",
                "user_link",
                "user_friends",
                "user_location",
                "user_likes",
                "user_photos",
                "user_videos",
                "user_posts"
                );

            if (string.IsNullOrEmpty(m_LoginResult.AccessToken) == false)
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                ApplicationSettings.Instance.AccessToken = m_LoginResult.AccessToken;
                fetchLoggedInUser();
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage);
            }
        }

        private void fetchLoggedInUser()
        {
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                string loggedInMsg = $"Logged in as {m_LoginResult.LoggedInUser.Name}";

                this.Text = loggedInMsg;
                buttonLogin.Text = loggedInMsg;
                buttonLogin.BackColor = Color.LightGreen;
                labelFullName.Text = m_LoginResult.LoggedInUser.Name;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                pictureBoxAppVisability.Visible = true;
                m_Controllers = new ControllersFacade.Controllers(m_LoggedInUser, searchableListBoxMain, progressBar);
                m_Controllers.DisablePictureBoxAppVisability += turnOfPictureBoxAppVisability;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                buttonTravelBuddy.Visible = true;
                buttonVolunteer.Visible = true;
            }
        }

        private void turnOfPictureBoxAppVisability()
        {
            pictureBoxAppVisability.Invoke(new Action(() => pictureBoxAppVisability.Visible = false));
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void logout()
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            checkBoxRememberMe.Checked = false;
            buttonTravelBuddy.Visible = false;
            buttonVolunteer.Visible = false;
            pictureBoxAppVisability.Visible = true;
        }

        private void buttonPhotos_Click(object sender, EventArgs e)
        {
            new Thread(() => showData(eControllerType.Photo)).Start();
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            new Thread(() => showData(eControllerType.Post)).Start();
        }

        private void buttonPages_Click(object sender, EventArgs e)
        {
            new Thread(() => showData(eControllerType.Page)).Start();
        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            new Thread(() => showData(eControllerType.Friend)).Start();
        }

        private void buttonStatuses_Click(object sender, EventArgs e)
        {
            new Thread(() => showData(eControllerType.Status)).Start();
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            new Thread(() => showData(eControllerType.Profile)).Start();
            setUserNameChangedEvent();
        }

        private void setUserNameChangedEvent()
        {
            ProfileController userProfile = m_Controllers.GetController(eControllerType.Profile) as ProfileController;

            userProfile.UserNameChanged -= updateUserName;
            userProfile.UserNameChanged += updateUserName;
        }

        private void updateUserName()
        {
            labelFullName.Text = m_LoginResult.LoggedInUser.Name;
        }

        private void searchableListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = (sender as SearchableListBoxController).SelectedItem;

            m_Controllers.ShowSelectedItem(selectedItem);
        }

        private void buttonTravelBuddy_Click(object sender, EventArgs e)
        {
            FormTravelBuddy formTravelBuddy = new FormTravelBuddy(m_LoginResult.LoggedInUser);

            formTravelBuddy.ShowDialog();
        }

        private void buttonVolunteer_Click(object sender, EventArgs e)
        {
            FormVolunteer formVolunteer = new FormVolunteer(m_LoginResult.LoggedInUser);

            formVolunteer.ShowDialog();
        }

        private void displayPanel(Panel i_Panel)
        {
            foreach (Panel panel in m_Panels.Values)
            {
                panel.Invoke(new Action(() => panel.Visible = false));
            }

            i_Panel.Invoke(new Action(() => i_Panel.Visible = true));
        }

        private void showData(eControllerType i_ControllerType)
        {
            Control controller = m_Controllers.GetController(i_ControllerType) as Control;
            Panel panel = m_Panels[i_ControllerType];

            progressBar.Invoke(new Action(() => progressBar.Visible = true));
            displayPanel(panel);

            try
            {
                m_Controllers.LoadDataToListBox(i_ControllerType);
                panel.Invoke(new Action(() =>
                {
                    panel.Controls.Clear();
                    panel.Controls.Add(controller);
                }));
            }
            catch (Exception ex)
            {
                string exceptionMsg = string.Format("Getting {0} is not supported by Meta anymore.{1}Press ok to continue.{1}Error: {2}",
                i_ControllerType.ToString(), Environment.NewLine, ex.Message);

                MessageBox.Show(exceptionMsg);
            }

            progressBar.Invoke(new Action(() => progressBar.Visible = false));
        }
    }
}