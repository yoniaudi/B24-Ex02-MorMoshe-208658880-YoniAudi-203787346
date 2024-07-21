using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormRemoveVolunteer : Form
    {
        private readonly RemoveVolunteerService r_VolunteerService = null;

        public FormRemoveVolunteer()
        {
            InitializeComponent();
            r_VolunteerService = new RemoveVolunteerService();
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void displayVolunteersWithPhoneNumber(string i_SelectedPhoneNumber)
        {
            List<VolunteerModel> volunteers = r_VolunteerService.LoadVolunteers();
            List<VolunteerModel> volunteersWithMatchingPhoneNumber = r_VolunteerService.
                FilterVolunteersByPhoneNumber(volunteers, i_SelectedPhoneNumber);
            List<string> volunteersForDisplay = volunteersWithMatchingPhoneNumber.
                Select(volunteer => volunteer.ToString()).ToList();

            listBoxVolunteers.DataSource = volunteersForDisplay;
        }

        private void buttonFindMyVolunteers_Click(object sender, EventArgs e)
        {
            findMyVolunteers();
        }

        private void findMyVolunteers()
        {
            string phoneNumber = textBoxPhone.Text;

            if (string.IsNullOrEmpty(phoneNumber) == false)
            {
                displayVolunteersWithPhoneNumber(phoneNumber);
            }
            else
            {
                MessageBox.Show("Enter a phone number.");
            }
        }

        private void buttonRemoveVolunteer_Click(object sender, EventArgs e)
        {
            removeVolunteer();
        }

        private void removeVolunteer()
        {
            if (listBoxVolunteers.SelectedIndex != -1)
            {
                string selectedVolunteerStr = (string)listBoxVolunteers.SelectedItem;
                VolunteerModel volunteerDetails = r_VolunteerService.ExtractVolunteerDetails(selectedVolunteerStr);
                List<VolunteerModel> volunteers = r_VolunteerService.LoadVolunteers();
                VolunteerModel selectedVolunteer = volunteers.FirstOrDefault(volunteer =>
                    volunteer.Subject == volunteerDetails.Subject &&
                    volunteer.Location == volunteerDetails.Location &&
                    volunteer.StartDate.Date == volunteerDetails.StartDate.Date &&
                    volunteer.EndDate.Date == volunteerDetails.EndDate.Date &&
                    volunteer.PhoneNumber == volunteerDetails.PhoneNumber);

                if (selectedVolunteer != null)
                {
                    r_VolunteerService.RemoveVolunteer(volunteers, selectedVolunteer);
                    displayVolunteersWithPhoneNumber(volunteerDetails.PhoneNumber);
                }
            }
        }
    }
}