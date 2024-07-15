using BasicFacebookFeatures.Features.ValidationStrategy;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public class AddVolunteerValidationStrategy : IValidationStrategy<VolunteerPerson>
    {
        public bool Validate(VolunteerPerson i_VolunteerPerson, out string o_ErrorMessage)
        {
            List<string> errorMessages = new List<string>();
            bool isDataValid = true;

            validateSubject(i_VolunteerPerson.Subject, errorMessages);
            validateLocation(i_VolunteerPerson.Location, errorMessages);
            validateDates(i_VolunteerPerson.StartDate, i_VolunteerPerson.EndDate, errorMessages);
            validatePhone(i_VolunteerPerson.PhoneNumber, errorMessages);

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

        private void validateSubject(string i_Subject, List<string> o_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_Subject) == true)
            {
                o_ErrorMessages.Add("Choose a subject.");
            }
        }

        private void validateLocation(string i_Location, List<string> o_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_Location) == true)
            {
                o_ErrorMessages.Add("Choose a location.");
            }
        }

        private void validateDates(DateTime i_StartDate, DateTime i_EndDate, List<string> o_ErrorMessages)
        {
            if (i_StartDate > i_EndDate)
            {
                o_ErrorMessages.Add("Invalid dates.");
            }
        }

        private void validatePhone(string i_PhoneNumber, List<string> o_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_PhoneNumber) == true)
            {
                o_ErrorMessages.Add("Invalid phone number.");
            }
        }
    }
}
