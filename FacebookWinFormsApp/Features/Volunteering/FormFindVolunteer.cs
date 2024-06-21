using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormFindVolunteer : Form
    {
        private User m_LoggedInUser = null;
        private string m_Subject = null;
        private string m_Location = null;
        private DateTime m_StartAvailableDate;
        private DateTime m_EndAvailableDate;

        public FormFindVolunteer()
        {
            InitializeComponent();
            m_StartAvailableDate = DateTime.Now;
            m_EndAvailableDate = DateTime.Now;
        }

        public FormFindVolunteer(User i_LoggedInUser)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;
            m_StartAvailableDate = DateTime.Now;
            m_EndAvailableDate = DateTime.Now;
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            m_StartAvailableDate = dateTimePickerStartDate.Value;
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            m_EndAvailableDate = dateTimePickerEndDate.Value;
        }

        private void buttonFindOpportunities_Click(object sender, EventArgs e)
        {
            listBoxFoundOpportunities.DataSource = null;

            if (checkDataValidation() == true)
            {
                List<VolunteerPerson> foundOpportunities = findMatchingOpportunities(m_Subject, m_Location, m_StartAvailableDate, m_EndAvailableDate);

                buttonFindOpportunities.Cursor = Cursors.AppStarting;
                displayVolunteerPlaces(foundOpportunities);
            }

            buttonFindOpportunities.Cursor = Cursors.Default;
        }

        private void displayVolunteerPlaces(List<VolunteerPerson> i_VolunteerPersons)
        {
            List<string> volunteers = new List<string>();

            foreach (VolunteerPerson person in i_VolunteerPersons)
            {
                string volunteer = person.ToString();

                volunteers.Add(volunteer);
            }

            listBoxFoundOpportunities.DataSource = volunteers;
        }

        private List<VolunteerPerson> findMatchingOpportunities(string i_Subject, string i_Location, DateTime i_StartDate, DateTime i_EndDate)
        {
            FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
            List<VolunteerPerson> opportunities = new List<VolunteerPerson>();
            List<VolunteerPerson> opportunitiesFromFile = null;

            foreach (User user in friends)
            {
                FacebookObjectCollection<Event> userEvents = user.Events;

                foreach (Event userEvent in userEvents)
                {
                    string eventName = userEvent.Name;
                    string eventLocation = userEvent.Location;
                    DateTime eventStartTime = userEvent.StartTime.GetValueOrDefault();
                    DateTime eventEndTime = userEvent.EndTime.GetValueOrDefault();

                    if (eventName.ToLower().Contains(i_Subject.ToLower()) &&
                        eventLocation.ToLower().Contains(i_Location.ToLower()) &&
                        eventStartTime.Date >= i_StartDate.Date && eventEndTime.Date <= i_EndDate.Date)
                    {
                        VolunteerPerson opportunity = new VolunteerPerson
                        {
                            Subject = i_Subject,
                            Location = eventLocation,
                            StartDate = eventStartTime,
                            EndDate = eventEndTime
                        };

                        opportunities.Add(opportunity);
                    }
                }
            }

            opportunitiesFromFile = FileOperations.LoadFromFile();

            if (opportunitiesFromFile.Count > 0)
            {
                foreach (VolunteerPerson person in opportunitiesFromFile)
                {
                    string eventName = person.Subject;
                    string eventLocation = person.Location;
                    string phoneNumber = person.PhoneNumber;
                    DateTime eventStartTime = person.StartDate;
                    DateTime eventEndTime = person.EndDate;

                    if (eventName.ToLower().Contains(i_Subject.ToLower()) &&
                        eventLocation.ToLower().Contains(i_Location.ToLower()) &&
                        eventStartTime.Date >= i_StartDate.Date && eventEndTime.Date <= i_EndDate.Date)
                    {
                        opportunities.Add(person);
                    }
                }
            }

            return opportunities;
        }

        private bool checkDataValidation()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(comboBoxSubject.Text) == false)
            {
                m_Subject = comboBoxSubject.Text;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Choose subject");
            }

            if (string.IsNullOrEmpty(textBoxLocation.Text) == false)
            {
                m_Location = textBoxLocation.Text;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Choose location");
            }

            if (String.IsNullOrEmpty(m_StartAvailableDate.ToString()) || String.IsNullOrEmpty(m_EndAvailableDate.ToString()) || m_StartAvailableDate > m_EndAvailableDate)
            {
                isValid = false;
                MessageBox.Show("Invalid dates");
            }

            return isValid;
        }
    }
}
