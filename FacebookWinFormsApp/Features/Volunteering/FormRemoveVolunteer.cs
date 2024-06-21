using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormRemoveVolunteer : Form
    {
        public FormRemoveVolunteer()
        {
            InitializeComponent();
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void displayVolunteersWithPhoneNumber(string i_SelectedPhoneNumber)
        {
            List<VolunteerPerson> volunteerPeople = FileOperations.LoadFromFile();
            List<string> volunteerPeopleToDisplay = new List<string>();
            List<VolunteerPerson> filteredVolunteers = volunteerPeople.Where(v => v.PhoneNumber == i_SelectedPhoneNumber).ToList();

            foreach (VolunteerPerson person in filteredVolunteers)
            {
                volunteerPeopleToDisplay.Add(person.ToString());
            }

            listBoxVolunteers.DataSource = volunteerPeopleToDisplay;
        }

        private void buttonFindMyVolunteers_Click(object sender, EventArgs e)
        {
            string phoneNumber = textBoxPhone.Text;

            if (String.IsNullOrEmpty(phoneNumber) == false)
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
                VolunteerPerson details = extractVolunteerDetails(selectedVolunteerString);
                List<VolunteerPerson> volunteerPeople = FileOperations.LoadFromFile();
                VolunteerPerson selectedVolunteer = volunteerPeople.FirstOrDefault(vp =>
                    vp.Subject == details.Subject &&
                    vp.Location == details.Location &&
                    vp.StartDate.Date == details.StartDate.Date &&
                    vp.EndDate.Date == details.EndDate.Date &&
                    vp.PhoneNumber == details.PhoneNumber);

                if (selectedVolunteer != null)
                {
                    volunteerPeople.Remove(selectedVolunteer);
                    FileOperations.SaveToFile(volunteerPeople);
                    displayVolunteersWithPhoneNumber(details.PhoneNumber);
                }
            }
        }

        private VolunteerPerson extractVolunteerDetails(string i_VolunteerString)
        {
            VolunteerPerson details = new VolunteerPerson();
            string[] parts = i_VolunteerString.Split(new string[] { " at ", " from ", " to ", " Phone:" }, StringSplitOptions.None);

            if (parts.Length == 5)
            {
                details.Subject = parts[0].Trim();
                details.Location = parts[1].Trim();
                details.StartDate = DateTime.Parse(parts[2].Trim()).Date;
                details.EndDate = DateTime.Parse(parts[3].Trim()).Date;
                details.PhoneNumber = parts[4].Trim();
            }

            return details;
        }
    }
}
