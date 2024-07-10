using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormFindVolunteer : Form
    {
        private readonly FindVolunteerService m_VolunteerService;

        public FormFindVolunteer(User i_LoggedInUser)
        {
            InitializeComponent();
            m_VolunteerService = new FindVolunteerService(i_LoggedInUser);
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerEndDate.Value = DateTime.Now;
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            m_VolunteerService.UpdateStartDate(dateTimePickerStartDate.Value);
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            m_VolunteerService.UpdateEndDate(dateTimePickerEndDate.Value);
        }

        private void buttonFindOpportunities_Click(object sender, EventArgs e)
        {
            VolunteerPerson volunteerPerson = collectFormData();

            if (m_VolunteerService.ValidateData(volunteerPerson, out string errorMessage))
            {
                buttonFindOpportunities.Cursor = Cursors.AppStarting;
                List<VolunteerPerson> foundOpportunities = m_VolunteerService.FindMatchingOpportunities(volunteerPerson);
                displayVolunteerPlaces(foundOpportunities);
                buttonFindOpportunities.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private VolunteerPerson collectFormData()
        {
            return new VolunteerPerson
            {
                Subject = comboBoxSubject.Text,
                Location = textBoxLocation.Text,
                StartDate = dateTimePickerStartDate.Value,
                EndDate = dateTimePickerEndDate.Value
            };
        }

        private void displayVolunteerPlaces(List<VolunteerPerson> i_VolunteerPersons)
        {
            List<string> volunteers = new List<string>();

            foreach (VolunteerPerson person in i_VolunteerPersons)
            {
                volunteers.Add(person.ToString());
            }

            listBoxFoundOpportunities.DataSource = volunteers;
        }
    }
}
