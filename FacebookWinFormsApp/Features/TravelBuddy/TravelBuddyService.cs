using BasicFacebookFeatures.Features.ValidationStrategy;
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
        public IValidationStrategy<TravelBuddyValidationData> ValidationStrategy { get; set; }

        public TravelBuddyService(User loggedInUser)
        {
            m_LoggedInUser = loggedInUser;
            ValidationStrategy = new TravelBuddyValidationStrategy();
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
            return ValidationStrategy.Validate(validationData, out errorMessage);
        }
    }
}
