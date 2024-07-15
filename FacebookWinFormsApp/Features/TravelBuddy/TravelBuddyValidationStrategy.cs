using BasicFacebookFeatures.Features.ValidationStrategy;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public class TravelBuddyValidationStrategy : IValidationStrategy<TravelBuddyValidationData>
    {
        public bool Validate(TravelBuddyValidationData i_ValidationData, out string o_ErrorMessage)
        {
            List<string> errorMessages = new List<string>();
            bool isDataValid = true;

            validateTravelCountry(i_ValidationData.SelectedCountry, errorMessages);
            validateTravelDates(i_ValidationData.ArrivalDate, i_ValidationData.DepartureDate, errorMessages);

            if (i_ValidationData.AgeChecked == true)
            {
                validateAgeRange(i_ValidationData.MinAge, i_ValidationData.MaxAge, errorMessages);
            }

            if (i_ValidationData.GenderChecked == true)
            {
                validateGender(i_ValidationData.Gender, errorMessages);
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

        private void validateTravelCountry(string i_Country, List<string> o_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_Country) == true)
            {
                o_ErrorMessages.Add("Choose a country.");
            }
        }

        private void validateTravelDates(string i_ArrivalDate, string i_DepartureDate, List<string> o_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_ArrivalDate) == true || string.IsNullOrEmpty(i_DepartureDate) == true ||
                DateTime.Parse(i_DepartureDate) < DateTime.Parse(i_ArrivalDate))
            {
                o_ErrorMessages.Add("Invalid Dates.");
            }
        }

        private void validateAgeRange(int i_MinAge, int i_MaxAge, List<string> o_ErrorMessages)
        {
            if (i_MinAge < 1 || i_MinAge > 120 || i_MaxAge < 1 || i_MaxAge > 120 || i_MaxAge < i_MinAge)
            {
                o_ErrorMessages.Add("Choose valid age range");
            }
        }

        private void validateGender(string i_Gender, List<string> o_ErrorMessages)
        {
            if (string.IsNullOrEmpty(i_Gender) == true)
            {
                o_ErrorMessages.Add("Choose gender");
            }
        }
    }
}