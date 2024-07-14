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
        private readonly User m_LoggedInUser;
        public IValidationStrategy<VolunteerPerson> ValidationStrategy { get; set; }

        public FindVolunteerService(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;
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

        public bool ValidateData(VolunteerPerson volunteerPerson, out string errorMessage)
        {
            return ValidationStrategy.Validate(volunteerPerson, out errorMessage);
        }

        public List<VolunteerPerson> FindMatchingOpportunities(VolunteerPerson volunteerPerson)
        {
            List<VolunteerPerson> opportunities = new List<VolunteerPerson>();
            opportunities.AddRange(findOpportunitiesFromFriends(volunteerPerson.Subject, volunteerPerson.Location));
            opportunities.AddRange(findOpportunitiesFromFile(volunteerPerson.Subject, volunteerPerson.Location));
            return opportunities;
        }

        private List<VolunteerPerson> findOpportunitiesFromFriends(string i_Subject, string i_Location)
        {
            FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
            List<VolunteerPerson> opportunities = new List<VolunteerPerson>();

            foreach (User user in friends)
            {
                FacebookObjectCollection<Event> userEvents = user.Events;

                foreach (Event userEvent in userEvents)
                {
                    string eventName = userEvent.Name;
                    string eventLocation = userEvent.Location;
                    DateTime eventStartTime = userEvent.StartTime.GetValueOrDefault();
                    DateTime eventEndTime = userEvent.EndTime.GetValueOrDefault();

                    if (eventName.ToLower() == i_Subject.ToLower() &&
                        eventLocation.ToLower() == i_Location.ToLower() &&
                        eventStartTime.Date >= StartAvailableDate.Date && eventEndTime.Date <= EndAvailableDate.Date)
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

            return opportunities;
        }

        private List<VolunteerPerson> findOpportunitiesFromFile(string i_Subject, string i_Location)
        {
            List<VolunteerPerson> opportunities = new List<VolunteerPerson>();
            List<VolunteerPerson> opportunitiesFromFile = Singleton<SingletonFileOperations>.Instance.LoadFromFile();

            if (opportunitiesFromFile != null)
            {
                foreach (VolunteerPerson person in opportunitiesFromFile)
                {
                    string eventName = person.Subject;
                    string eventLocation = person.Location;
                    DateTime eventStartTime = person.StartDate;
                    DateTime eventEndTime = person.EndDate;

                    if (eventName.ToLower() == i_Subject.ToLower() &&
                        eventLocation.ToLower() == i_Location.ToLower() &&
                        eventStartTime.Date >= StartAvailableDate.Date && eventEndTime.Date <= EndAvailableDate.Date)
                    {
                        opportunities.Add(person);
                    }
                }
            }

            return opportunities;
        }
    }
}
