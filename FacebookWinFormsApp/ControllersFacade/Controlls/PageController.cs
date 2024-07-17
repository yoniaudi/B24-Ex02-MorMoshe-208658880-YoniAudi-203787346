using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class PageController : UserControl, IController
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public PageController()
        {
            InitializeComponent();
        }

        public PageController(FacebookObjectCollection<Page> i_Pages, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            m_SearchableListBox = i_SearchableListBox;
            initializeProgressBar(i_Pages);
            DataSource = filterPostsWithProgress(i_Pages);
        }

        private void initializeProgressBar(FacebookObjectCollection<Page> i_Pages)
        {
            m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Maximum += i_Pages.Count));
        }

        private object filterPostsWithProgress(FacebookObjectCollection<Page> i_Pages)
        {
            FacebookObjectCollection<Page> filteredPages = new FacebookObjectCollection<Page>();

            foreach (Page page in i_Pages)
            {
                if (page.Name != null)
                {
                    filteredPages.Add(page);
                }

                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
            }

            return filteredPages;
        }

        public void LoadDataToListBox()
        {
            m_SearchableListBox.Invoke(new Action(() =>
            {
                m_SearchableListBox.DisplayMember = DisplayMember;
                m_SearchableListBox.DataSource = DataSource;
            }));
        }

        public void ShowSelectedItem(object i_Page)
        {
            Page page = i_Page as Page;

            labelPageName.Text = page.Name;
            pictureBoxCheckin.ImageLocation = page.PictureURL;
        }
    }
}