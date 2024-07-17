using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Page = FacebookWrapper.ObjectModel.Page;

namespace BasicFacebookFeatures.Models
{
    public partial class FriendController : UserControl, IController
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public FriendController()
        {
            InitializeComponent();
        }

        public FriendController(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            DataSource = i_LoggedInUser.Friends;
            m_ProgressBar = i_ProgressBar;
            m_SearchableListBox = i_SearchableListBox;
        }

        private void initializeProgressBar(User i_Friend)
        {
            m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Maximum += i_Friend.Statuses.Count));
        }

        private object filterStatusesWithProgress(User i_Friend)
        {
            List<FacebookWrapper.ObjectModel.Status> filteredStatuses = new List<FacebookWrapper.ObjectModel.Status>();

            foreach (FacebookWrapper.ObjectModel.Status status in i_Friend.Statuses)
            {
                if (status.Message != null)
                {
                    filteredStatuses.Add(status);
                }

                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
            }

            return filteredStatuses;
        }

        private object filterAlbumsWithProgress(User i_Friend)
        {
            List<Album> filteredAlbums = new List<Album>();

            try
            {
                foreach (Album album in i_Friend.Albums)
                {
                    if (album.Count > 0)
                    {
                        filteredAlbums.Add(album);
                    }

                    m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
                }
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }

            return filteredAlbums;
        }

        private void searchableListBoxControllerFriendAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album album = searchableListBoxControllerFriendAlbums.SelectedItem as Album;

            flowLayoutPanelFriendPhotos.Controls.Clear();
            statusesModelFriendStatuses.Hide();
            flowLayoutPanelFriendPhotos.Show();

            if (album != null)
            {
                for (int i = 0; i < album.Photos.Count; i++)
                {
                    PictureBox picture = new PictureBox();

                    picture.Name = $"pictureBox{i}";
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    picture.ImageLocation = album.Photos[i].PictureThumbURL;
                    flowLayoutPanelFriendPhotos.Controls.Add(picture);
                    picture.BringToFront();
                    picture.Visible = true;
                    m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
                }
            }
        }

        private string getLanguagesStr(Page[] i_Languages)
        {
            StringBuilder languages = new StringBuilder();

            if (i_Languages != null)
            {
                foreach (FacebookWrapper.ObjectModel.Page languagePage in i_Languages)
                {
                    string languageName = languagePage.Name.Remove(languagePage.Name.Length - "Language".Length - 1);

                    languages.Append($"{languageName}, ");
                    m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
                }
            }

            return languages.ToString().TrimEnd(',', ' ');
        }

        private void searchableListBoxControllerFriendsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FacebookWrapper.ObjectModel.Status status = searchableListBoxControllerFriendsStatus.SelectedItem as FacebookWrapper.ObjectModel.Status;
            statusesModelFriendStatuses.ShowSelectedItem(status);
            flowLayoutPanelFriendPhotos.Hide();
            statusesModelFriendStatuses.Show();
            m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
        }

        public void LoadDataToListBox()
        {
            m_SearchableListBox.Invoke(new Action(() =>
            {
                m_SearchableListBox.DisplayMember = DisplayMember;
                m_SearchableListBox.DataSource = DataSource;
            }));
        }

        public void ShowSelectedItem(object i_Friend)
        {
            User friend = i_Friend as User;
            FacebookObjectCollection<User> mainUserFriends = (FacebookObjectCollection<User>)DataSource;

            initializeProgressBar(friend);
            flowLayoutPanelFriendPhotos.Controls.Clear();
            labelFriendFullName.Text = friend.Name;
            pictureBoxFriendProfile.ImageLocation = friend.PictureNormalURL;
            labelUserFriendBirthday.Text = friend.Birthday;
            labelUserFriendLocation.Text = friend.Location != null ? friend.Location.Name : "";
            labelUserFriendEmail.Text = friend.Email;
            labelUserFriendLanguages.Text = getLanguagesStr(friend.Languages);
            labelFriendStatuses.Text = $"{friend.FirstName} Statuses:";
            searchableListBoxControllerFriendsStatus.DisplayMember = "Message";
            searchableListBoxControllerFriendsStatus.DataSource = filterStatusesWithProgress(friend);
            searchableListBoxControllerFriendAlbums.DisplayMember = "Name";
            searchableListBoxControllerFriendAlbums.DataSource = filterAlbumsWithProgress(friend);
            labelFriendsOfFriend.Text = $"{friend.FirstName} Friends:";
            searchableListBoxControllerFriendsOfFriend.DisplayMember = "Name";
            searchableListBoxControllerFriendsOfFriend.DataSource = friend.Friends;
            searchableListBoxControllerCommonFriends.DisplayMember = "Name";
            searchableListBoxControllerCommonFriends.DataSource = friend.Friends.Where(myFriend => mainUserFriends.Contains(myFriend)).ToList();
            m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Visible = false));
        }
    }
}