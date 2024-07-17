using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class StatusController : UserControl, IController
    {
        public string DisplayMember { get { return "Message"; } }
        public object DataSource { get; set; }
        private System.Windows.Forms.ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public StatusController()
        {
            InitializeComponent();
        }

        public StatusController(FacebookObjectCollection<FacebookWrapper.ObjectModel.Status> i_Statuses, SearchableListBoxController i_SearchableListBox, System.Windows.Forms.ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            m_SearchableListBox = i_SearchableListBox;
            initializeProgressBar(i_Statuses);
            DataSource = filterStatusesWithProgress(i_Statuses);
        }

        private void initializeProgressBar(FacebookObjectCollection<FacebookWrapper.ObjectModel.Status> i_Statuses)
        {
            m_ProgressBar.Invoke(new Action(() => m_ProgressBar.Maximum += i_Statuses.Count));
        }

        private object filterStatusesWithProgress(FacebookObjectCollection<FacebookWrapper.ObjectModel.Status> i_Statuses)
        {
            FacebookObjectCollection<FacebookWrapper.ObjectModel.Status> filteredStatuses = new FacebookObjectCollection<FacebookWrapper.ObjectModel.Status>();

            foreach (FacebookWrapper.ObjectModel.Status status in i_Statuses)
            {
                if (status.Message != null)
                {
                    filteredStatuses.Add(status);
                }

                m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
            }

            return filteredStatuses;
        }

        public void LoadDataToListBox()
        {
            m_SearchableListBox.Invoke(new Action(() =>
            {
                m_SearchableListBox.DisplayMember = DisplayMember;
                m_SearchableListBox.DataSource = DataSource;
            }));
        }

        public void ShowSelectedItem(object i_Status)
        {
            FacebookWrapper.ObjectModel.Status status = i_Status as FacebookWrapper.ObjectModel.Status;

            if (status != null)
            {
                string authorName = status.From != null ? status.From.Name : "";
                string dateCreated = status.CreatedTime != null ? status.CreatedTime.ToString() : "";
                string message = status.Message != null ? status.Message : "";

                labelUserAuthor.Text = authorName;
                labelUserDateCreated.Text = dateCreated;
                richTextBoxUserMessage.Text = message;
            }
        }
    }
}
