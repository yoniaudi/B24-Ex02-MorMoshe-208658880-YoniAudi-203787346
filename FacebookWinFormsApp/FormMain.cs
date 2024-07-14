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
        private FacebookWrapper.LoginResult m_LoginResult = null;
        private User m_LoggedInUser = null;
        private PhotosController m_Photos = null;
        private PostController m_Posts = null;
        private PageController m_Pages = null;
        private ProfileController m_Profile = null;
        private FriendController m_Friends = null;
        private StatusController m_Statuses = null;
        private Panel[] m_Panels = null;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
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
            new Thread(fetchPhotos).Start();
        }

        private void fetchPhotos()
        {
            progressBar.Invoke(new Action(() => progressBar.Visible = true));

            try
            {
                m_Photos = new Models.PhotosController(m_LoginResult.LoggedInUser.Albums, progressBar);
                panelPhotos.Invoke(new Action(() =>
                {
                    panelPhotos.Controls.Clear();
                    panelPhotos.Controls.Add(m_Photos);
                }));
                searchableListBoxMain.Invoke(new Action(() =>
                {
                    searchableListBoxMain.DisplayMember = m_Photos.DisplayMember;
                    searchableListBoxMain.DataSource = m_Photos.DataSource;
                }));
                displayPanel(panelPhotos);
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }
            
            progressBar.Invoke(new Action(() => progressBar.Visible = false));
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            new Thread(fetchPosts).Start();
        }

        private void fetchPosts()
        {
            progressBar.Invoke(new Action(() => progressBar.Visible = true));
            m_Posts = new Models.PostController(m_LoginResult.LoggedInUser.Posts, progressBar);
            panelPosts.Invoke(new Action(() =>
            {
                panelPosts.Controls.Clear();
                panelPosts.Controls.Add(m_Posts);
            }));
            searchableListBoxMain.Invoke(new Action(() =>
            {
                searchableListBoxMain.DisplayMember = m_Posts.DisplayMember;
                searchableListBoxMain.DataSource = m_Posts.DataSource;
            }));
            displayPanel(panelPosts);
            progressBar.Invoke(new Action(() => progressBar.Visible = false));
        }

        private void buttonPages_Click(object sender, EventArgs e)
        {
            new Thread(fetchPages).Start();
        }

        private void fetchPages()
        {
            progressBar.Invoke(new Action(() => progressBar.Visible = true));
            m_Pages = new Models.PageController(m_LoginResult.LoggedInUser.LikedPages, progressBar);
            panelPages.Invoke(new Action(() =>
            {
                panelPages.Controls.Clear();
                panelPages.Controls.Add(m_Pages);
            }));
            searchableListBoxMain.Invoke(new Action(() =>
            {
                searchableListBoxMain.DisplayMember = m_Pages.DisplayMember;
                searchableListBoxMain.DataSource = m_Pages.DataSource;
            }));
            displayPanel(panelPages);
            progressBar.Invoke(new Action(() => progressBar.Visible = false));
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            new Thread(fetchProfile).Start();
        }

        private void fetchProfile()
        {
            m_Profile = new ProfileController(m_LoginResult.LoggedInUser, labelFullName);
            searchableListBoxMain.Invoke(new Action(() => searchableListBoxMain.DataSource = null));
            panelProfile.Invoke(new Action(() =>
            {
                panelProfile.Controls.Clear();
                panelProfile.Controls.Add(m_Profile);
            }));
            displayPanel(panelProfile);
        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            new Thread(fetchFriends).Start();
        }

        private void fetchFriends()
        {
            progressBar.Invoke(new Action(() => progressBar.Visible = true));
            m_Friends = new FriendController(m_LoginResult.LoggedInUser.Friends, progressBar);
            panelFriends.Invoke(new Action(() =>
            {
                panelFriends.Controls.Clear();
                panelFriends.Controls.Add(m_Friends);
            }));
            searchableListBoxMain.Invoke(new Action(() =>
            {
                searchableListBoxMain.DisplayMember = m_Friends.DisplayMember;
                searchableListBoxMain.DataSource = m_Friends.DataSource;
            }));
            displayPanel(panelFriends);
            progressBar.Invoke(new Action(() => progressBar.Visible = false));
        }

        private void buttonStatuses_Click(object sender, EventArgs e)
        {
            new Thread(fetchStatus).Start();
        }

        private void fetchStatus()
        {
            progressBar.Invoke(new Action(() => progressBar.Visible = true));
            m_Statuses = new Models.StatusController(m_LoginResult.LoggedInUser.Statuses, progressBar);
            panelStatuses.Invoke(new Action(() =>
            {
                panelStatuses.Controls.Clear();
                panelStatuses.Controls.Add(m_Statuses);
            }));
            searchableListBoxMain.Invoke(new Action(() =>
            {
                searchableListBoxMain.DisplayMember = m_Statuses.DisplayMember;
                searchableListBoxMain.DataSource = m_Statuses.DataSource;
            }));
            displayPanel(panelStatuses);
            progressBar.Invoke(new Action(() => progressBar.Visible = false));
        }
        
        private void searchableListBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = (sender as SearchableListBoxController).SelectedItem;

            switch (selectedItem)
            {
                case Album album:
                    m_Photos.ShowSelectedAlbum(album);
                    break;
                case Post post:
                    m_Posts.Invoke(new Action(() => m_Posts.ShowSelectedPost(post)));
                    break;
                case Page page:
                    m_Pages.Invoke(new Action(() => m_Pages.ShowSelectedPage(page)));
                    break;
                case User user:
                    m_Friends.ShowSelectedFriend(user);
                    break;
                case Status status:
                    m_Statuses.ShowSelectedStatus(status);
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