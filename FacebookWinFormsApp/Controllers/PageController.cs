using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class PageController : UserControl
    {
        public string DisplayMember { get { return "Name"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;

        public PageController()
        {
            InitializeComponent();
        }

        public PageController(FacebookObjectCollection<Page> i_Pages, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            initializeProgressBar(i_Pages);
            DataSource = filterPostsWithProgress(i_Pages);
        }

        private void initializeProgressBar(FacebookObjectCollection<Page> i_Pages)
        {
            m_ProgressBar.Minimum = 1;
            m_ProgressBar.Maximum = i_Pages.Count;
            m_ProgressBar.Value = 1;
            m_ProgressBar.Step = 1;
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

                m_ProgressBar.PerformStep();
            }

            return filteredPages;
        }

        public void ShowSelectedPage(Page i_Page)
        {
            labelPageName.Text = i_Page.Name;
            pictureBoxCheckin.ImageLocation = i_Page.PictureURL;
        }
    }
}