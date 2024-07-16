using BasicFacebookFeatures.Features.TravelBuddy;
using BasicFacebookFeatures.Features.Volunteering;
using BasicFacebookFeatures.Models;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Page = FacebookWrapper.ObjectModel.Page;
using Status = FacebookWrapper.ObjectModel.Status;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult = null;
        private User m_LoggedInUser = null;
        private ProfileController m_Profile = null;
        private Panel[] m_Panels = null;
        private ControllersFacade.Controllers m_Controllers = null;

        public FormMain()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 25;
            m_Panels = new Panel[] 
            {
                panelProfile,
                panelFriends,
                panelStatuses,
                panelInbox,
                panelPhotos,
                panelPosts,
                panelPages
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

                progressBar.PerformStep();
                this.Text = loggedInMsg;
                buttonLogin.Text = loggedInMsg;
                buttonLogin.BackColor = Color.LightGreen;
                labelFullName.Text = m_LoginResult.LoggedInUser.Name;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                buttonTravelBuddy.Visible = true;
                buttonVolunteer.Visible = true;
                m_Controllers = new ControllersFacade.Controllers(m_LoggedInUser, searchableListBoxMain, progressBar);
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
            fetchPhotos();
        }

        private void fetchPhotos()
        {
            if (m_Controllers.GetController(new Album()) != null)
            {
                try
                {
                    panelPhotos.Controls.Clear();
                    panelPhotos.Controls.Add(m_Controllers.GetController(new Album()) as Control);
                    displayPanel(panelPhotos);
                }
                catch (Exception ex)
                {
                    string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                        Environment.NewLine, ex.Message);

                    MessageBox.Show(exMsg);
                }
            }
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            fetchPosts();
        }

        private void fetchPosts()
        {
            if (m_Controllers.GetController(new Post()) != null)
            {
                m_Controllers.ShowPosts();
                panelPosts.Controls.Clear();
                panelPosts.Controls.Add(m_Controllers.GetController(new Post()) as Control);
                displayPanel(panelPosts);
            }
        }

        private void buttonPages_Click(object sender, EventArgs e)
        {
            fetchPages();
        }

        private void fetchPages()
        {
            if (m_Controllers.GetController(new Page()) != null)
            {
                m_Controllers.ShowPages();
                panelPages.Controls.Clear();
                panelPages.Controls.Add(m_Controllers.GetController(new Page()) as Control);
                displayPanel(panelPages);
            }
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            fetchProfile();
        }

        private void fetchProfile()
        {
            m_Profile = new ProfileController(m_LoginResult.LoggedInUser);
            m_Profile.UserNameChanged += reportUserNameChange;
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
            fetchFriends();
        }

        private void fetchFriends()
        {
            if (m_Controllers.GetController(new User()) != null)
            {
                m_Controllers.ShowFriends();
                panelFriends.Controls.Clear();
                panelFriends.Controls.Add(m_Controllers.GetController(new User()) as Control);
                displayPanel(panelFriends);
            }   
        }

        private void buttonStatuses_Click(object sender, EventArgs e)
        {
            fetchStatus();
        }

        private void fetchStatus()
        {
            if (m_Controllers.GetController(new Status()) != null)
            {
                m_Controllers.ShowStatuses();
                panelStatuses.Controls.Clear();
                panelStatuses.Controls.Add(m_Controllers.GetController(new Status()) as Control);
                displayPanel(panelStatuses);
            }
        }

        private void searchableListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = (sender as SearchableListBoxController).SelectedItem;

            switch (selectedItem)
            {
                case Album album:
                    m_Controllers.ShowSelectedAlbum(album);
                    break;
                case Post post:
                    m_Controllers.ShowSelectedPost(post);
                    break;
                case Page page:
                    m_Controllers.ShowSelectedPage(page);
                    break;
                case User user:
                    m_Controllers.ShowSelectedFriend(user);
                    break;
                case Status status:
                    m_Controllers.ShowSelectedStatus(status);
                    break;
                default:
                    break;
            }
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
            foreach (Panel panel in m_Panels)
            {
                panel.Invoke(new Action(() => panel.Visible = false));
            }

            i_Panel.Invoke(new Action(() => i_Panel.Visible = true));
        }
    }
}