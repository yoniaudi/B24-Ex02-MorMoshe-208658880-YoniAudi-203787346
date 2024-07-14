using BasicFacebookFeatures.Features.ValidationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public class TravelBuddyValidationStrategy : IValidationStrategy<TravelBuddyValidationData>
    {
        public bool Validate(TravelBuddyValidationData validationData, out string errorMessage)
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
