using FacebookWrapper.ObjectModel;
using System.Text;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Models
{
    public partial class ProfileController : UserControl
    {
        private User m_LoggedInUser = null;

        public ProfileController()
        {
            InitializeComponent();
        }

        public ProfileController(User i_LoggedInUser)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;
            fetchProfileData();
        }

        private void fetchProfileData()
        {
            labelUserFirstName.Text = m_LoggedInUser.FirstName;
            labelUserLastName.Text = m_LoggedInUser.LastName;
            labelUserBirthday.Text = m_LoggedInUser.Birthday;
            labelUserLocation.Text = m_LoggedInUser.Location.Name;
            labelUserEmailAddress.Text = m_LoggedInUser.Email;
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
    }
}