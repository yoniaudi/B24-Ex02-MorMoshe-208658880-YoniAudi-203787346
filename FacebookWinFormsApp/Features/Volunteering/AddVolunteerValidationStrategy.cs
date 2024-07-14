using BasicFacebookFeatures.Features.ValidationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public class AddVolunteerValidationStrategy : IValidationStrategy<VolunteerPerson>
    {
        public bool Validate(VolunteerPerson volunteerPerson, out string errorMessage)
        {
            List<string> errorMessages = new List<string>();

            validateSubject(volunteerPerson.Subject, errorMessages);
            validateLocation(volunteerPerson.Location, errorMessages);
            validateDates(volunteerPerson.StartDate, volunteerPerson.EndDate, errorMessages);
            validatePhone(volunteerPerson.PhoneNumber, errorMessages);

            if (errorMessages.Count > 0)
            {
                errorMessage = string.Join(Environment.NewLine, errorMessages);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private void validateSubject(string subject, List<string> errorMessages)
        {
            if (string.IsNullOrEmpty(subject))
            {
                errorMessages.Add("Choose subject");
            }
        }

        private void validateLocation(string location, List<string> errorMessages)
        {
            if (string.IsNullOrEmpty(location))
            {
                errorMessages.Add("Choose location");
            }
        }

        private void validateDates(DateTime startDate, DateTime endDate, List<string> errorMessages)
        {
            if (startDate > endDate)
            {
                errorMessages.Add("Invalid dates");
            }
        }

        private void validatePhone(string phone, List<string> errorMessages)
        {
            if (string.IsNullOrEmpty(phone))
            {
                errorMessages.Add("Invalid phone number");
            }
        }
    }
}
