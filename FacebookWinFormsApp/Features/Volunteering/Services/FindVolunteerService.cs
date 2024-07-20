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
        public IValidation<VolunteerModel> Validations { get; set; }
        private readonly User r_LoggedInUser;

        public FindVolunteerService(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
            StartAvailableDate = DateTime.Now;
            EndAvailableDate = DateTime.Now;
        }

        public void UpdateStartDate(DateTime i_StartDate)
        {
            StartAvailableDate = i_StartDate;
        }

        public void UpdateEndDate(DateTime i_EndDate)
        {
            EndAvailableDate = i_EndDate;
        }

        public bool DataValidation(VolunteerModel i_Volunteer, out string o_ErrorMessage)
        {
            List<string> errorMessages = new List<string>();
            bool isDataValid = true;

            Validations = new VolunteerCategoryValidation();
            Validations.Validate(i_Volunteer, errorMessages);
            Validations = new VolunteerLocationValidation();
            Validations.Validate(i_Volunteer, errorMessages);
            Validations = new VolunteerDateValidation();
            Validations.Validate(i_Volunteer, errorMessages);

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

        public List<VolunteerModel> FindMatchingOpportunities(VolunteerModel i_Volunteer)
        {
            List<VolunteerModel> opportunities = new List<VolunteerModel>();

            opportunities.AddRange(findOpportunitiesFromFriends(i_Volunteer.Subject, i_Volunteer.Location));
            opportunities.AddRange(findOpportunitiesFromFile(i_Volunteer.Subject, i_Volunteer.Location));

            return opportunities;
        }

        private List<VolunteerModel> findOpportunitiesFromFriends(string i_Subject, string i_Location)
        {
            FacebookObjectCollection<User> friends = r_LoggedInUser.Friends;
            List<VolunteerModel> opportunities = new List<VolunteerModel>();

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
                        VolunteerModel opportunity = new VolunteerModel
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

        private List<VolunteerModel> findOpportunitiesFromFile(string i_Subject, string i_Location)
        {
            List<VolunteerModel> opportunities = new List<VolunteerModel>();
            List<VolunteerModel> opportunitiesFromFile = Singleton<SingletonFileOperations>.Instance.LoadFromFile();

            if (opportunitiesFromFile != null)
            {
                foreach (VolunteerModel volunteer in opportunitiesFromFile)
                {
                    string eventName = volunteer.Subject;
                    string eventLocation = volunteer.Location;
                    DateTime eventStartTime = volunteer.StartDate;
                    DateTime eventEndTime = volunteer.EndDate;
                    bool isOpportunityFound = eventName.ToLower() == i_Subject.ToLower() &&
                        eventLocation.ToLower() == i_Location.ToLower() &&
                        eventStartTime.Date >= StartAvailableDate.Date &&
                        eventEndTime.Date <= EndAvailableDate.Date;

                    if (isOpportunityFound == true)
                    {
                        opportunities.Add(volunteer);
                    }
                }
            }

            return opportunities;
        }
    }
}