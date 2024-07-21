using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.ValidationStrategy.TravelBuddyValidations
{
    public class TravelCountryValidation : IValidation<TravelBuddyData>
    {
        public bool Validate(TravelBuddyData i_Data, List<string> i_ErrorMessages)
        {
            bool isTravelCountryValid = true;

            if (string.IsNullOrEmpty(i_Data.SelectedCountry) == true)
            {
                i_ErrorMessages.Add("Choose a country.");
                isTravelCountryValid = true;
            }

            return isTravelCountryValid;
        }
    }
}