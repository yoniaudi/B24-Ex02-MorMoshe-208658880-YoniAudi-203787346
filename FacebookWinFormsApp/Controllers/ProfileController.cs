using FacebookWrapper.ObjectModel;
using System;
using System.Text;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class ProfileController : UserControl
    {
        private User m_LoggedInUser = null;
        private Label m_LabelUserFullName = null;
        public event Action UserNameChanged = null;

        public ProfileController()
        {
            InitializeComponent();
        }

        public ProfileController(User i_LoggedInUser, Label i_LabelUserFullName)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;
            m_LabelUserFullName = i_LabelUserFullName;
            fetchProfileData();
        }

        private void fetchProfileData()
        {
            userBindingSource.DataSource = m_LoggedInUser;
            labelUserLanguages.Text = getLanguagesStr(m_LoggedInUser.Languages);
        }

        private string getLanguagesStr(Page[] i_Languages)
        {
            StringBuilder languages = new StringBuilder();

            foreach (Page languagePage in m_LoggedInUser.Languages)
            {
                string languageName = languagePage.Name.Remove(languagePage.Name.Length - "Language".Length - 1);

                languages.Append($"{languageName}, ");
            }

            return languages.ToString().TrimEnd(',', ' ');
        }

        private void textBoxUserFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validatingUserFullName(sender, e);
        }

        private void textBoxUserLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validatingUserFullName(sender, e);
        }

        private void validatingUserFullName(object i_Sender, System.ComponentModel.CancelEventArgs i_E)
        {
            TextBox textBoxNewName = i_Sender as TextBox;

            if (textBoxNewName.Text.Length == 0)
            {
                string[] fullName = m_LoggedInUser.Name.Split(' ');

                if (textBoxNewName.Name == "textBoxUserFirstName")
                {
                    textBoxNewName.Text = fullName[0];
                }
                else
                {
                    textBoxNewName.Text = fullName[1];
                }

                MessageBox.Show("Textbox can't be empty.");
                i_E.Cancel = true;
            }
        }

        private void textBoxUserFirstName_Validated(object sender, System.EventArgs e)
        {
            OnUserNameChanged();
        }

        private void textBoxUserLastName_Validated(object sender, System.EventArgs e)
        {
            OnUserNameChanged();
        }

        private void OnUserNameChanged()
        {
            string newUserName = $"{m_LoggedInUser.FirstName} {m_LoggedInUser.LastName}";

            m_LoggedInUser.Name = newUserName;
            UserNameChanged?.Invoke();
        }
    }
}