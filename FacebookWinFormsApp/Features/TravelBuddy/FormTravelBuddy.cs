using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public partial class FormTravelBuddy : Form
    {
        private User m_LoggedInUser;
        private DateTime m_ArrivalDate;
        private DateTime m_DepartureDate;
        private string m_SelectedCountry;
        private string m_Gender = null;
        private int m_MinAge = 0;
        private int m_MaxAge = 0;
        private bool m_SelectingArrival = true;

        public FormTravelBuddy()
        {
            InitializeComponent();
            populateComboBoxCountires();
        }

        public FormTravelBuddy(User i_LoggedInUser)
        {
            InitializeComponent();
            populateComboBoxCountires();
            m_LoggedInUser = i_LoggedInUser;
        }

        private void populateComboBoxCountires()
        {
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo region = new RegionInfo(culture.Name);

                if (comboBoxCountries.Items.Contains(region.EnglishName) == false)
                {
                    comboBoxCountries.Items.Add(region.EnglishName);
                }
            }

            comboBoxCountries.Sorted = true;
        }

        private void checkBoxAge_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAge.Checked)
            {
                labelAgeRange.Visible = true;
                textBoxMinAge.Visible = true;
                textBoxMaxAge.Visible = true;
            }
            else
            {
                labelAgeRange.Visible = false;
                textBoxMinAge.Visible = false;
                textBoxMaxAge.Visible = false;
            }
        }

        private void checkBoxGender_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGender.Checked)
            {
                comboBoxGender.Visible = true;
            }
            else
            {
                comboBoxGender.Visible = false;
            }
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
            if (Char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBoxMaxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void buttonFindMatch_Click(object sender, EventArgs e)
        {
            if (checkInputValidation() == true)
            {
                List<TravelBuddyModel> friendsList = null;

                listBoxTravelBuddies.DataSource = null;
                listBoxTraveledFriends.DataSource = null;
                listBoxTravelBuddies.Items.Clear();
                listBoxTraveledFriends.Items.Clear();
                buttonFindMatch.Cursor = Cursors.AppStarting;
                friendsList = loadFriends();
                findMatch(friendsList);
                findFriendsWhoTraveledDestCountry(friendsList);
            }

            buttonFindMatch.Cursor = Cursors.Default;
        }

        private void findMatch(List<TravelBuddyModel> i_FriendsList)
        {
            List<TravelBuddyModel> friendsWithPlannedTravel = new List<TravelBuddyModel>();

            friendsWithPlannedTravel = checkFriendsForPlannedTravel(i_FriendsList, m_SelectedCountry, m_ArrivalDate, m_DepartureDate, m_MinAge, m_MaxAge, m_Gender);
            listBoxTravelBuddies.DisplayMember = "Name";
            listBoxTravelBuddies.DataSource = friendsWithPlannedTravel;
        }

        private void findFriendsWhoTraveledDestCountry(List<TravelBuddyModel> i_FriendsList)
        {
            List<TravelBuddyModel> friendsTraveledDesiredCountry = checkFriendsForDesiredCountry(i_FriendsList, m_SelectedCountry);

            listBoxTraveledFriends.DisplayMember = "Name";
            listBoxTraveledFriends.DataSource = friendsTraveledDesiredCountry;
        }

        private bool checkInputValidation()
        {
            bool isValid = true;

            m_SelectedCountry = comboBoxCountries.Text;

            if (string.IsNullOrEmpty(m_SelectedCountry))
            {
                isValid = false;
                MessageBox.Show("Choose country");
            }

            if (string.IsNullOrEmpty(textBoxArrivalDate.Text) || string.IsNullOrEmpty(textBoxDepartureDate.Text) || m_DepartureDate < m_ArrivalDate)
            {
                isValid = false;
                MessageBox.Show("Invalid Dates");
            }

            if (checkBoxAge.Checked == true)
            {
                if (string.IsNullOrEmpty(textBoxMinAge.Text) == false && string.IsNullOrEmpty(textBoxMaxAge.Text) == false)
                {
                    m_MinAge = int.Parse(textBoxMinAge.Text);
                    m_MaxAge = int.Parse(textBoxMaxAge.Text);

                    if (m_MinAge < 1 || m_MinAge > 120 || m_MaxAge < 1 || m_MaxAge > 120)
                    {
                        isValid = false;
                        MessageBox.Show("Choose age between 1 to 120");
                    }
                    else if (m_MaxAge < m_MinAge)
                    {
                        isValid = false;
                        MessageBox.Show("Invalid age range");
                    }
                }
                else
                {
                    isValid = false;
                    MessageBox.Show("Choose age");
                }
            }

            if (checkBoxGender.Checked == true)
            {
                if (string.IsNullOrEmpty(comboBoxGender.Text) == false)
                {
                    m_Gender = comboBoxGender.Text;
                }
                else
                {
                    isValid = false;
                    MessageBox.Show("Choose gender");
                }
            }

            return isValid;
        }

        private List<TravelBuddyModel> loadFriends()
        {
            FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
            TravelBuddyModel travelBuddyFriend = null;
            FacebookObjectCollection<Event> events = null;
            List<TravelBuddyModel> friendList = new List<TravelBuddyModel>();

            foreach (User fbFriend in friends)
            {
                int age = fbFriend.Birthday != null ? calculateAge(fbFriend.Birthday) : 0;
                List<string> traveledCountries = new List<string>();

                if (fbFriend.Albums != null)
                {
                    foreach (Album album in fbFriend.Albums)
                    {
                        foreach (Photo photo in album.Photos)
                        {
                            if (photo.Place != null && string.IsNullOrEmpty(photo.Place.Location.Country) == false)
                            {
                                if (traveledCountries.Contains(photo.Place.Location.Country) == false)
                                {
                                    traveledCountries.Add(photo.Place.Location.Country);
                                }
                            }
                        }
                    }
                }

                travelBuddyFriend = new TravelBuddyModel()
                {
                    Name = fbFriend.Name,
                    Age = age,
                    Gender = fbFriend.Gender.ToString(),
                    TraveledCountries = traveledCountries
                };

                events = fbFriend.Events;

                foreach (Event fbEvent in events)
                {
                    if (fbEvent.Place != null && fbEvent.Place.Location != null)
                    {
                        string country = fbEvent.Place.Location.Country;
                        DateTime startDate = fbEvent.StartTime ?? DateTime.MinValue;
                        DateTime endDate = fbEvent.EndTime ?? startDate;

                        if (string.IsNullOrEmpty(country) == false)
                        {
                            travelBuddyFriend.TravelPlans.Add(new TravelPlanModel
                            {
                                Country = country,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }
                    }
                }

                friendList.Add(travelBuddyFriend);
            }

            return friendList;
        }

        private int calculateAge(string i_Birthday)
        {
            int age = 0;
            DateTime birthDate;

            if (DateTime.TryParse(i_Birthday, out birthDate))
            {
                age = DateTime.Now.Year - birthDate.Year;

                if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                {
                    age--;
                }
            }

            return age;
        }

        private List<TravelBuddyModel> checkFriendsForDesiredCountry(List<TravelBuddyModel> i_FriendsList, string i_DesiredCountry)
        {
            List<TravelBuddyModel> friendsInDesiredCountry = new List<TravelBuddyModel>();

            foreach (TravelBuddyModel friend in i_FriendsList)
            {
                if (friend.TraveledCountries.Contains(i_DesiredCountry))
                {
                    friendsInDesiredCountry.Add(friend);
                }
            }

            return friendsInDesiredCountry;
        }

        private List<TravelBuddyModel> checkFriendsForPlannedTravel(List<TravelBuddyModel> i_FriendsList, string i_DesiredCountry, DateTime i_StartDate, DateTime i_EndDate, int i_MinAge = 0, int i_MaxAge = 0, string i_Gender = null)
        {
            List<TravelBuddyModel> friendsWithPlannedTravel = new List<TravelBuddyModel>();

            foreach (TravelBuddyModel friend in i_FriendsList)
            {
                foreach (TravelPlanModel travelPlan in friend.TravelPlans)
                {
                    if (travelPlan.Country == i_DesiredCountry && travelPlan.StartDate <= i_EndDate && travelPlan.EndDate >= i_StartDate)
                    {
                        bool ageCondition = (i_MinAge == 0 && i_MaxAge == 0) || (friend.Age >= i_MinAge && friend.Age <= i_MaxAge);
                        bool genderCondition = i_Gender == null || friend.Gender == i_Gender;

                        if (ageCondition && genderCondition)
                        {
                            friendsWithPlannedTravel.Add(friend);
                            break;
                        }
                    }
                }
            }

            return friendsWithPlannedTravel;
        }
    }
}