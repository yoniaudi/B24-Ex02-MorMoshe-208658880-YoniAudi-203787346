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
        private readonly TravelBuddyService r_TravelBuddyService = null;
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
            r_TravelBuddyService = new TravelBuddyService(i_LoggedInUser);
        }

        private void populateComboBoxCountries()
        {
            IOrderedEnumerable<string> countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
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
            if (m_SelectingArrival == true)
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
            ageValidation(e);
        }

        private void textBoxMaxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            ageValidation(e);
        }

        private void ageValidation(KeyPressEventArgs i_E)
        {
            if (!Char.IsDigit(i_E.KeyChar) && i_E.KeyChar != '\b')
            {
                i_E.Handled = true;
            }
        }

        private void buttonFindMatch_Click(object sender, EventArgs e)
        {
            findMatchValidation();
        }

        private void findMatchValidation()
        {
            TravelBuddyData validationData = new TravelBuddyData
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

            if (r_TravelBuddyService.DataValidation(validationData, out string errorMessage))
            {
                List<TravelBuddyModel> friendsList = r_TravelBuddyService.LoadFriends();

                listBoxTravelBuddies.DataSource = null;
                listBoxTraveledFriends.DataSource = null;
                listBoxTravelBuddies.Items.Clear();
                listBoxTraveledFriends.Items.Clear();
                buttonFindMatch.Cursor = Cursors.AppStarting;
                findMatch(friendsList);
                findFriendsWhoTraveledDestCountry(friendsList);
                buttonFindMatch.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void findMatch(List<TravelBuddyModel> i_FriendList)
        {
            List<TravelBuddyModel> friendsWithPlannedTravel = r_TravelBuddyService
                .FindFriendsWithPlannedTravel(i_FriendList, m_SelectedCountry, m_ArrivalDate,
                    m_DepartureDate, m_MinAge, m_MaxAge, m_Gender);

            listBoxTravelBuddies.DisplayMember = "Name";
            listBoxTravelBuddies.DataSource = friendsWithPlannedTravel;
        }

        private void findFriendsWhoTraveledDestCountry(List<TravelBuddyModel> i_FriendsList)
        {
            List<TravelBuddyModel> friendsTraveledDesiredCountry = r_TravelBuddyService
                .FindFriendsForDesiredCountry(i_FriendsList, m_SelectedCountry);

            listBoxTraveledFriends.DisplayMember = "Name";
            listBoxTraveledFriends.DataSource = friendsTraveledDesiredCountry;
        }
    }
}
