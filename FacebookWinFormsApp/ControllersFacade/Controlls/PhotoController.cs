using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class PhotoController : UserControl, IController
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public PhotoController()
        {
            InitializeComponent();
        }

        public PhotoController(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            InitializeComponent();

            try
            {
                m_ProgressBar = i_ProgressBar;
                m_SearchableListBox = i_SearchableListBox;
                initializeProgressBar(i_LoggedInUser.Albums);
                DataSource = filterAlbumsWithProgress(i_LoggedInUser.Albums);
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }
        }

        private void initializeProgressBar(FacebookObjectCollection<Album> i_Albums = null, FacebookWrapper.ObjectModel.Album i_Album = null)
        {

            m_ProgressBar.Invoke(new Action(() =>
                m_ProgressBar.Maximum += i_Albums != null ? i_Albums.Count : (i_Album != null ? i_Album.Photos.Count : 0)));
        }

        private object filterAlbumsWithProgress(FacebookObjectCollection<Album> i_Albums)
        {
            FacebookObjectCollection<Album> filteredAlbums = new FacebookObjectCollection<Album>();

            foreach (FacebookWrapper.ObjectModel.Album album in i_Albums)
            {
                if (album.Count > 0)
                {
                    filteredAlbums.Add(album);
                }

                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
            }

            return filteredAlbums;
        }

        public void LoadDataToListBox()
        {
            if (m_SearchableListBox != null)
            {
                m_SearchableListBox.Invoke(new Action(() =>
                {
                    m_SearchableListBox.DisplayMember = DisplayMember;
                    m_SearchableListBox.DataSource = DataSource;
                }));
            }
        }

        public void ShowSelectedItem(object i_Album)
        {
            Album album = i_Album as Album;

            initializeProgressBar(null, album);
            flowLayoutPanelPhotos.Controls.Clear();

            for (int i = 0; i < album.Photos.Count; i++)
            {
                PictureBox picture = new PictureBox();

                picture.Name = $"pictureBox{i}";
                picture.SizeMode = PictureBoxSizeMode.AutoSize;
                picture.ImageLocation = album.Photos[i].PictureThumbURL;
                flowLayoutPanelPhotos.Controls.Add(picture);
                picture.BringToFront();
                picture.Visible = true;
                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
            }
        }
    }
}
