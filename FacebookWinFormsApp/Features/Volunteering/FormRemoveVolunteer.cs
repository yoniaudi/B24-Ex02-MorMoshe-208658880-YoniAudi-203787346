using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormRemoveVolunteer : Form
    {
        private readonly RemoveVolunteerService m_VolunteerService;

        public FormRemoveVolunteer()
        {
            InitializeComponent();
            m_VolunteerService = new RemoveVolunteerService();
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void displayVolunteersWithPhoneNumber(string selectedPhoneNumber)
        {
            List<VolunteerPerson> volunteerPeople = m_VolunteerService.LoadVolunteers();
            List<VolunteerPerson> filteredVolunteers = m_VolunteerService.FilterVolunteersByPhoneNumber(volunteerPeople, selectedPhoneNumber);
            List<string> volunteerPeopleToDisplay = filteredVolunteers.Select(person => person.ToString()).ToList();

            listBoxVolunteers.DataSource = volunteerPeopleToDisplay;
        }

        private void buttonFindMyVolunteers_Click(object sender, EventArgs e)
        {
            string phoneNumber = textBoxPhone.Text;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                displayVolunteersWithPhoneNumber(phoneNumber);
            }
            else
            {
                MessageBox.Show("Enter phone number");
            }
        }

        private void buttonRemoveVolunteer_Click(object sender, EventArgs e)
        {
            if (listBoxVolunteers.SelectedIndex != -1)
            {
                string selectedVolunteerString = (string)listBoxVolunteers.SelectedItem;
                VolunteerPerson details = m_VolunteerService.ExtractVolunteerDetails(selectedVolunteerString);
                List<VolunteerPerson> volunteerPeople = m_VolunteerService.LoadVolunteers();
                VolunteerPerson selectedVolunteer = volunteerPeople.FirstOrDefault(vp =>
                    vp.Subject == details.Subject &&
                    vp.Location == details.Location &&
                    vp.StartDate.Date == details.StartDate.Date &&
                    vp.EndDate.Date == details.EndDate.Date &&
                    vp.PhoneNumber == details.PhoneNumber);

                if (selectedVolunteer != null)
                {
                    m_VolunteerService.RemoveVolunteer(volunteerPeople, selectedVolunteer);
                    displayVolunteersWithPhoneNumber(details.PhoneNumber);
                }
            }
        }
    }
}
