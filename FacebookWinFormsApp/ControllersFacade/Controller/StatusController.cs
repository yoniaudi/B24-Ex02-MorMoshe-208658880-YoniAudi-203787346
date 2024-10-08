﻿using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class StatusController : UserControl, IController
    {
        public string DisplayMember { get { return "Message"; } }
        public object DataSource { get; set; }
        private ProgressBar m_ProgressBar = null;
        private SearchableListBoxController m_SearchableListBox = null;

        public StatusController()
        {
            InitializeComponent();
        }

        public StatusController(User i_LoggedInUser, SearchableListBoxController i_SearchableListBox, ProgressBar i_ProgressBar)
        {
            InitializeComponent();
            m_ProgressBar = i_ProgressBar;
            m_SearchableListBox = i_SearchableListBox;
            initializeProgressBar(i_LoggedInUser.Statuses);
            DataSource = filterStatusesWithProgress(i_LoggedInUser.Statuses);
        }

        private void initializeProgressBar(FacebookObjectCollection<Status> i_Statuses)
        {
            if (m_ProgressBar?.IsHandleCreated == true)
            {
                m_ProgressBar?.Invoke(new Action(() => m_ProgressBar.Maximum += i_Statuses.Count));
            }
        }

        private object filterStatusesWithProgress(FacebookObjectCollection<Status> i_Statuses)
        {
            FacebookObjectCollection<Status> filteredStatuses = new FacebookObjectCollection<Status>();

            foreach (Status status in i_Statuses)
            {
                if (status.Message != null)
                {
                    filteredStatuses.Add(status);
                }

                if (m_ProgressBar?.IsHandleCreated == true)
                {
                    m_ProgressBar.Invoke(new Action(() => m_ProgressBar.PerformStep()));
                }
            }

            return filteredStatuses;
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

        public void ShowSelectedItem(object i_Status)
        {
            Status status = i_Status as Status;

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
