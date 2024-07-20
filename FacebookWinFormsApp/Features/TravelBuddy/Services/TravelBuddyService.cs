using BasicFacebookFeatures.Features.ValidationStrategy;
using BasicFacebookFeatures.Features.ValidationStrategy.TravelBuddyValidations;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public class TravelBuddyService
    {
        private readonly User r_LoggedInUser = null;
        private IValidation<TravelBuddyData> m_Validation { get; set; } = null;

        public TravelBuddyService(User loggedInUser)
        {
            r_LoggedInUser = loggedInUser;
        }

        public List<TravelBuddyModel> LoadFriends()
        {
            FacebookObjectCollection<User> friends = r_LoggedInUser.Friends;
            List<TravelBuddyModel> friendList = new List<TravelBuddyModel>();

            foreach (User friend in friends)
            {
                int age = friend.Birthday != null ? calculateAge(friend.Birthday) : 0;
                List<string> traveledCountries = getTraveledCountries(friend);

                TravelBuddyModel travelBuddyFriend = new TravelBuddyModel
                {
                    Name = friend.Name,
                    Age = age,
                    Gender = friend.Gender.ToString(),
                    TraveledCountries = traveledCountries,
                    TravelPlans = getTravelPlans(friend)
                };

                friendList.Add(travelBuddyFriend);
            }

            return friendList;
        }

        private List<string> getTraveledCountries(User i_Friend)
        {
            List<string> traveledCountries = new List<string>();

            try
            {
                if (i_Friend.Albums != null)
                {
                    foreach (Album album in i_Friend.Albums)
                    {
                        foreach (Photo photo in album.Photos)
                        {
                            bool hasBeenInThisCountry = photo.Place?.Location?.Country != null
                                && !traveledCountries.Contains(photo.Place.Location.Country);

                            if (hasBeenInThisCountry == true)
                            {
                                traveledCountries.Add(photo.Place.Location.Country);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exMsg = string.Format("Getting albums is not supported by Meta anymore.{0}Press ok to continue.{0}Error: {1}",
                    Environment.NewLine, ex.Message);

                MessageBox.Show(exMsg);
            }

            return traveledCountries;
        }

        private List<TravelPlanModel> getTravelPlans(User i_Friend)
        {
            List<TravelPlanModel> travelPlans = new List<TravelPlanModel>();

            if (i_Friend.Events != null)
            {
                foreach (Event friendEvent in i_Friend.Events)
                {
                    if (friendEvent.Place?.Location?.Country != null)
                    {
                        travelPlans.Add(new TravelPlanModel
                        {
                            Country = friendEvent.Place.Location.Country,
                            StartDate = friendEvent.StartTime ?? DateTime.MinValue,
                            EndDate = friendEvent.EndTime ?? friendEvent.StartTime ?? DateTime.MinValue
                        });
                    }
                }
            }

            return travelPlans;
        }

        private int calculateAge(string i_Birthday)
        {
            int age = 0;

            if (DateTime.TryParse(i_Birthday, out DateTime birthDate))
            {
                age = DateTime.Now.Year - birthDate.Year;

                if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                {
                    age--;
                }
            }

            return age;
        }

        public List<TravelBuddyModel> FindFriendsForDesiredCountry(List<TravelBuddyModel> i_FriendList, string i_DesiredCountry)
        {
            return i_FriendList.Where(friend => friend.TraveledCountries.Contains(i_DesiredCountry)).ToList();
        }

        public List<TravelBuddyModel> FindFriendsWithPlannedTravel(List<TravelBuddyModel> i_FriendList, string i_DesiredCountry,
            DateTime i_StartDate, DateTime i_EndDate, int i_MinAge = 0, int i_MaxAge = 0, string i_Gender = null)
        {
            List<TravelBuddyModel> friendsWithPlannedTravel = i_FriendList.Where(friend => friend.TravelPlans.Any(travelPlan =>
                    travelPlan.Country == i_DesiredCountry &&
                    travelPlan.StartDate <= i_EndDate &&
                    travelPlan.EndDate >= i_StartDate) &&
                    (i_MinAge == 0 && i_MaxAge == 0 || friend.Age >= i_MinAge && friend.Age <= i_MaxAge) &&
                    (i_Gender == null || friend.Gender == i_Gender)).ToList();
            
            return friendsWithPlannedTravel;
        }

        public bool DataValidation(TravelBuddyData i_ValidationData, out string o_ErrorMessage)
        {
            List<string> errorMessages = new List<string>();
            bool isDataValid = true;

            m_Validation = new TravelCountryValidation();
            m_Validation.Validate(i_ValidationData, errorMessages);
            m_Validation = new TravelDateValidation();
            m_Validation.Validate(i_ValidationData, errorMessages);

            if (i_ValidationData.AgeChecked == true)
            {
                m_Validation = new TravelAgeRangeValidation();
                m_Validation.Validate(i_ValidationData, errorMessages);
            }

            if (i_ValidationData.GenderChecked == true)
            {
                m_Validation = new TravelGenderValidation();
                m_Validation.Validate(i_ValidationData, errorMessages);
            }

            if (errorMessages.Count > 0)
            {
                o_ErrorMessage = string.Join(Environment.NewLine, errorMessages);
                isDataValid = false;
            }
            else
            {
                o_ErrorMessage = string.Empty;
            }

            return isDataValid;
        }
    }
}
