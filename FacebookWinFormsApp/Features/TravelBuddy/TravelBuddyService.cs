using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public class TravelBuddyService
    {
        private readonly User m_LoggedInUser;

        public TravelBuddyService(User loggedInUser)
        {
            m_LoggedInUser = loggedInUser;
        }

        public List<TravelBuddyModel> LoadFriends()
        {
            FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
            List<TravelBuddyModel> friendList = new List<TravelBuddyModel>();

            foreach (User fbFriend in friends)
            {
                int age = fbFriend.Birthday != null ? CalculateAge(fbFriend.Birthday) : 0;
                List<string> traveledCountries = GetTraveledCountries(fbFriend);

                TravelBuddyModel travelBuddyFriend = new TravelBuddyModel
                {
                    Name = fbFriend.Name,
                    Age = age,
                    Gender = fbFriend.Gender.ToString(),
                    TraveledCountries = traveledCountries,
                    TravelPlans = GetTravelPlans(fbFriend)
                };

                friendList.Add(travelBuddyFriend);
            }

            return friendList;
        }

        private List<string> GetTraveledCountries(User fbFriend)
        {
            List<string> traveledCountries = new List<string>();

            if (fbFriend.Albums != null)
            {
                foreach (Album album in fbFriend.Albums)
                {
                    foreach (Photo photo in album.Photos)
                    {
                        if (photo.Place?.Location?.Country != null && !traveledCountries.Contains(photo.Place.Location.Country))
                        {
                            traveledCountries.Add(photo.Place.Location.Country);
                        }
                    }
                }
            }

            return traveledCountries;
        }

        private List<TravelPlanModel> GetTravelPlans(User fbFriend)
        {
            List<TravelPlanModel> travelPlans = new List<TravelPlanModel>();

            if (fbFriend.Events != null)
            {
                foreach (Event fbEvent in fbFriend.Events)
                {
                    if (fbEvent.Place?.Location?.Country != null)
                    {
                        travelPlans.Add(new TravelPlanModel
                        {
                            Country = fbEvent.Place.Location.Country,
                            StartDate = fbEvent.StartTime ?? DateTime.MinValue,
                            EndDate = fbEvent.EndTime ?? fbEvent.StartTime ?? DateTime.MinValue
                        });
                    }
                }
            }

            return travelPlans;
        }

        public int CalculateAge(string birthday)
        {
            if (DateTime.TryParse(birthday, out DateTime birthDate))
            {
                int age = DateTime.Now.Year - birthDate.Year;
                if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                {
                    age--;
                }
                return age;
            }
            return 0;
        }

        public List<TravelBuddyModel> FindFriendsForDesiredCountry(List<TravelBuddyModel> friendsList, string desiredCountry)
        {
            return friendsList.Where(friend => friend.TraveledCountries.Contains(desiredCountry)).ToList();
        }

        public List<TravelBuddyModel> FindFriendsWithPlannedTravel(List<TravelBuddyModel> friendsList, string desiredCountry, DateTime startDate, DateTime endDate, int minAge = 0, int maxAge = 0, string gender = null)
        {
            return friendsList.Where(friend =>
                friend.TravelPlans.Any(plan =>
                    plan.Country == desiredCountry &&
                    plan.StartDate <= endDate &&
                    plan.EndDate >= startDate) &&
                (minAge == 0 && maxAge == 0 || (friend.Age >= minAge && friend.Age <= maxAge)) &&
                (gender == null || friend.Gender == gender)).ToList();
        }

        public bool ValidateData(TravelBuddyValidationData validationData, out string errorMessage)
        {
            List<string> errorMessages = new List<string>();

            validateCountry(validationData.SelectedCountry, errorMessages);
            validateDates(validationData.ArrivalDate, validationData.DepartureDate, errorMessages);

            if (validationData.AgeChecked)
            {
                validateAgeRange(validationData.MinAge, validationData.MaxAge, errorMessages);
            }

            if (validationData.GenderChecked)
            {
                validateGender(validationData.Gender, errorMessages);
            }

            if (errorMessages.Count > 0)
            {
                errorMessage = string.Join(Environment.NewLine, errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private void validateCountry(string country, List<string> errorMessages)
        {
            if (string.IsNullOrEmpty(country))
            {
                errorMessages.Add("Choose country");
            }
        }

        private void validateDates(string arrivalDate, string departureDate, List<string> errorMessages)
        {
            if (string.IsNullOrEmpty(arrivalDate) || string.IsNullOrEmpty(departureDate) || DateTime.Parse(departureDate) < DateTime.Parse(arrivalDate))
            {
                errorMessages.Add("Invalid Dates");
            }
        }

        private void validateAgeRange(int minAge, int maxAge, List<string> errorMessages)
        {
            if (minAge < 1 || minAge > 120 || maxAge < 1 || maxAge > 120 || maxAge < minAge)
            {
                errorMessages.Add("Choose valid age range");
            }
        }

        private void validateGender(string gender, List<string> errorMessages)
        {
            if (string.IsNullOrEmpty(gender))
            {
                errorMessages.Add("Choose gender");
            }
        }
    }
}
