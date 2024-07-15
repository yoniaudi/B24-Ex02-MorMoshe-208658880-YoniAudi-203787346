using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormVolunteer : Form
    {
        private User m_LoggedInUser = null;
        public FormVolunteer()
        {
            InitializeComponent();
        }

        public FormVolunteer(User i_LoggedInUser)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;
        }

        private void buttonFindVolunteer_Click(object sender, EventArgs e)
        {
            FormFindVolunteer formMatchVolunteer = new FormFindVolunteer(m_LoggedInUser);

            formMatchVolunteer.ShowDialog();
        }

        private void buttonAddVolunteer_Click(object sender, EventArgs e)
        {
            FormAddVolunteer formAddVolunteer = new FormAddVolunteer();

            formAddVolunteer.ShowDialog();
        }

        private void buttonRemoveVolunteer_Click(object sender, EventArgs e)
        {
            FormRemoveVolunteer formRemoveVolunteer = new FormRemoveVolunteer();

            formRemoveVolunteer.ShowDialog();
        }
    }
}
