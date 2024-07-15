using BasicFacebookFeatures.Features.ValidationStrategy;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public class FindVolunteerService
    {
        public DateTime StartAvailableDate { get; private set; }
        public DateTime EndAvailableDate { get; private set; }
        public IValidationStrategy<Volunteer> ValidationStrategy { get; set; }
        private readonly User r_LoggedInUser;

        public FindVolunteerService(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
            StartAvailableDate = DateTime.Now;
            EndAvailableDate = DateTime.Now;
            ValidationStrategy = new FindVolunteerValidationStrategy();
        }

        public void UpdateStartDate(DateTime i_StartDate)
        {
            StartAvailableDate = i_StartDate;
        }

        public void UpdateEndDate(DateTime i_EndDate)
        {
            EndAvailableDate = i_EndDate;
        }

        public bool ValidateData(Volunteer i_Volunteer, out string o_ErrorMessage)
        {
            return ValidationStrategy.Validate(i_Volunteer, out o_ErrorMessage);
        }

        public List<Volunteer> FindMatchingOpportunities(Volunteer i_Volunteer)
        {
            List<Volunteer> opportunities = new List<Volunteer>();

            opportunities.AddRange(findOpportunitiesFromFriends(i_Volunteer.Subject, i_Volunteer.Location));
            opportunities.AddRange(findOpportunitiesFromFile(i_Volunteer.Subject, i_Volunteer.Location));

            return opportunities;
        }

        private List<Volunteer> findOpportunitiesFromFriends(string i_Subject, string i_Location)
        {
            FacebookObjectCollection<User> friends = r_LoggedInUser.Friends;
            List<Volunteer> opportunities = new List<Volunteer>();

            foreach (User friend in friends)
            {
                FacebookObjectCollection<Event> friendEvents = friend.Events;

                foreach (Event friendEvent in friendEvents)
                {
                    string eventName = friendEvent.Name;
                    string eventLocation = friendEvent.Location;
                    DateTime eventStartTime = friendEvent.StartTime.GetValueOrDefault();
                    DateTime eventEndTime = friendEvent.EndTime.GetValueOrDefault();

                    if (eventName.ToLower() == i_Subject.ToLower() &&
                        eventLocation.ToLower() == i_Location.ToLower() &&
                        eventStartTime.Date >= StartAvailableDate.Date &&
                        eventEndTime.Date <= EndAvailableDate.Date)
                    {
                        Volunteer opportunity = new Volunteer
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

            return opportunities;
        }

        private List<Volunteer> findOpportunitiesFromFile(string i_Subject, string i_Location)
        {
            List<Volunteer> opportunities = new List<Volunteer>();
            List<Volunteer> opportunitiesFromFile = Singleton<SingletonFileOperations>.Instance.LoadFromFile();

            if (opportunitiesFromFile != null)
            {
                foreach (Volunteer volunteer in opportunitiesFromFile)
                {
                    string eventName = volunteer.Subject;
                    string eventLocation = volunteer.Location;
                    DateTime eventStartTime = volunteer.StartDate;
                    DateTime eventEndTime = volunteer.EndDate;

                    if (eventName.ToLower() == i_Subject.ToLower() &&
                        eventLocation.ToLower() == i_Location.ToLower() &&
                        eventStartTime.Date >= StartAvailableDate.Date &&
                        eventEndTime.Date <= EndAvailableDate.Date)
                    {
                        opportunities.Add(volunteer);
                    }
                }
            }

            return opportunities;
        }
    }
}