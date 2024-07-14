using FacebookWrapper.ObjectModel;
using System.Text;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class ProfileController : UserControl
    {
        private User m_LoggedInUser = null;
        private Label m_LabelUserFullName = null;

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
            updateUserFullName(sender, e);
        }

        private void textBoxUserLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updateUserFullName(sender, e);
        }

        private void updateUserFullName(object i_Sender, System.ComponentModel.CancelEventArgs i_E)
        {
            if ((i_Sender as TextBox).Text.Length == 0)
            {
                MessageBox.Show("Textbox can't be empty.");
                i_E.Cancel = true;
            }
            else
            {
                string fullName = $"{m_LoggedInUser.FirstName} {m_LoggedInUser.LastName}";

                m_LoggedInUser.Name = fullName;
                m_LabelUserFullName.Text = fullName;
            }
        }
    }
}