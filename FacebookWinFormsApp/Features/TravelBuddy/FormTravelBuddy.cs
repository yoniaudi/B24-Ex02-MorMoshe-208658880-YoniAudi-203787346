using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public partial class FormTravelBuddy : Form
    {
        private readonly TravelBuddyService m_TravelBuddyService;
        private DateTime m_ArrivalDate;
        private DateTime m_DepartureDate;
        private string m_SelectedCountry = null;
        private string m_Gender = null;
        private int m_MinAge = 0;
        private int m_MaxAge = 0;
        private bool m_SelectingArrival = true;

        public FormTravelBuddy(User i_LoggedInUser)
        {
            InitializeComponent();
            populateComboBoxCountries();
            m_TravelBuddyService = new TravelBuddyService(i_LoggedInUser);
        }

        private void populateComboBoxCountries()
        {
            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                           .Select(culture => new RegionInfo(culture.Name).EnglishName)
                           .Distinct()
                           .OrderBy(name => name);

            comboBoxCountries.Items.AddRange(countries.ToArray());
        }

        private void checkBoxAge_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxAge.Checked;
            labelAgeRange.Visible = isChecked;
            textBoxMinAge.Visible = isChecked;
            textBoxMaxAge.Visible = isChecked;
        }

        private void checkBoxGender_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxGender.Visible = checkBoxGender.Checked;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (m_SelectingArrival)
            {
                m_ArrivalDate = e.Start;
                textBoxArrivalDate.Text = m_ArrivalDate.ToShortDateString();
                m_SelectingArrival = false;
            }
            else
            {
                m_DepartureDate = e.Start;
                textBoxDepartureDate.Text = m_DepartureDate.ToShortDateString();
                m_SelectingArrival = true;
            }
        }

        private void textBoxArrivalDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBoxDepartureDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBoxMinAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void buttonFindMatch_Click(object sender, EventArgs e)
        {
            var validationData = new TravelBuddyValidationData
            {
                SelectedCountry = comboBoxCountries.Text,
                ArrivalDate = textBoxArrivalDate.Text,
                DepartureDate = textBoxDepartureDate.Text,
                MinAge = !string.IsNullOrEmpty(textBoxMinAge.Text) ? int.Parse(textBoxMinAge.Text) : 0,
                MaxAge = !string.IsNullOrEmpty(textBoxMaxAge.Text) ? int.Parse(textBoxMaxAge.Text) : 0,
                AgeChecked = checkBoxAge.Checked,
                GenderChecked = checkBoxGender.Checked,
                Gender = comboBoxGender.Text
            };

            if (m_TravelBuddyService.ValidateData(validationData, out string errorMessage))
            {
                listBoxTravelBuddies.DataSource = null;
                listBoxTraveledFriends.DataSource = null;
                listBoxTravelBuddies.Items.Clear();
                listBoxTraveledFriends.Items.Clear();
                buttonFindMatch.Cursor = Cursors.AppStarting;

                var friendsList = m_TravelBuddyService.LoadFriends();
                findMatch(friendsList);
                findFriendsWhoTraveledDestCountry(friendsList);

                buttonFindMatch.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void findMatch(List<TravelBuddyModel> friendsList)
        {
            var friendsWithPlannedTravel = m_TravelBuddyService.FindFriendsWithPlannedTravel(friendsList, m_SelectedCountry, m_ArrivalDate, m_DepartureDate, m_MinAge, m_MaxAge, m_Gender);
            listBoxTravelBuddies.DisplayMember = "Name";
            listBoxTravelBuddies.DataSource = friendsWithPlannedTravel;
        }

        private void findFriendsWhoTraveledDestCountry(List<TravelBuddyModel> friendsList)
        {
            var friendsTraveledDesiredCountry = m_TravelBuddyService.FindFriendsForDesiredCountry(friendsList, m_SelectedCountry);
            listBoxTraveledFriends.DisplayMember = "Name";
            listBoxTraveledFriends.DataSource = friendsTraveledDesiredCountry;
        }
    }
}
