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
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult = null;
        private User m_LoggedInUser = null;
        private ProfileController m_Profile = null;
        private Dictionary<eControllerType, Panel> m_Panels = null;
        private ControllersFacade.Controllers m_Controllers = null;

        public FormMain()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 25;
            m_Panels = new Dictionary<eControllerType, Panel>()
            {
                {eControllerType.Photo, panelPhotos },
                {eControllerType.Post, panelPosts },
                {eControllerType.Page, panelPages },
                {eControllerType.Friend, panelFriends },
                {eControllerType.Status, panelStatuses },
                {eControllerType.Profile, panelProfile }
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
                m_Controllers = new ControllersFacade.Controllers(m_LoggedInUser, searchableListBoxMain, progressBar);
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                buttonTravelBuddy.Visible = true;
                buttonVolunteer.Visible = true;
                pictureBoxAppVisability.Visible = false;
            }
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
            showData(eControllerType.Photo);
            displayPanel(panelPhotos);
        }

        private void showData(eControllerType i_ControllerType)
        {
            Control controller = m_Controllers.GetController(i_ControllerType) as Control;

            if (controller != null)
            {
                try
                {
                    m_Controllers.LoadDataToListBox(i_ControllerType);
                    m_Panels[i_ControllerType].Controls.Clear();
                    m_Panels[i_ControllerType].Controls.Add(controller);
                }
                catch (Exception ex)
                {
                    string exceptionMsg = string.Format("Getting {0} is not supported by Meta anymore.{1}Press ok to continue.{1}Error: {2}",
                    i_ControllerType.ToString(), Environment.NewLine, ex.Message);

                    MessageBox.Show(exceptionMsg);
                }
            }
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            showData(eControllerType.Post);
            displayPanel(panelPosts);
        }

        private void buttonPages_Click(object sender, EventArgs e)
        {
            showData(eControllerType.Page);
            displayPanel(panelPages);
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            showProfile();
        }

        private void showProfile()
        {
            m_Profile = new ProfileController(m_LoginResult.LoggedInUser);

            if (m_Profile == null)
            {
                m_Profile.UserNameChanged += reportUserNameChange; /////////////             Need to have protection so it wont be greater than one.
            }

            searchableListBoxMain.Invoke(new Action(() => searchableListBoxMain.DataSource = null));
            panelProfile.Controls.Clear();
            panelProfile.Controls.Add(m_Profile);
            displayPanel(panelProfile);
        }

        private void reportUserNameChange()
        {
            labelFullName.Text = m_LoginResult.LoggedInUser.Name;
        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            showData(eControllerType.Friend);
            displayPanel(panelFriends);
        }

        private void buttonStatuses_Click(object sender, EventArgs e)
        {
            showData(eControllerType.Status);
            displayPanel(panelStatuses);
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
    }
}