using BasicFacebookFeatures.Features.ValidationStrategy;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public class AddVolunteerValidationStrategy : IValidationStrategy<VolunteerModel>
    {
        public bool Validate(VolunteerModel i_Volunteer, out string o_ErrorMessage)
        {
            List<string> errorMessages = new List<string>();
            bool isDataValid = true;

            validateSubject(i_Volunteer.Subject, errorMessages);
            validateLocation(i_Volunteer.Location, errorMessages);
            validateDates(i_Volunteer.StartDate, i_Volunteer.EndDate, errorMessages);
            validatePhone(i_Volunteer.PhoneNumber, errorMessages);

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

        private void validateSubject(string i_Subject, List<string> i_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_Subject) == true)
            {
                i_ErrorMessages.Add("Choose a subject.");
            }
        }

        private void validateLocation(string i_Location, List<string> i_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_Location) == true)
            {
                i_ErrorMessages.Add("Choose a location.");
            }
        }

        private void validateDates(DateTime i_StartDate, DateTime i_EndDate, List<string> i_ErrorMessages)
        {
            if (i_StartDate > i_EndDate)
            {
                i_ErrorMessages.Add("Invalid dates.");
            }
        }

        private void validatePhone(string i_PhoneNumber, List<string> i_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_PhoneNumber) == true)
            {
                i_ErrorMessages.Add("Invalid phone number.");
            }
        }
    }
}
