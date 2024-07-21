using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class TravelAgeRangeValidation : IValidation<TravelBuddyData>
    {
        public bool Validate(TravelBuddyData i_Data, List<string> i_ErrorMessages)
        {
            bool isAgeRangeValid = true;

            if (i_Data.MinAge < 1 || i_Data.MinAge > 120 || i_Data.MaxAge < 1 || i_Data.MaxAge > 120 || i_Data.MaxAge < i_Data.MinAge)
            {
                i_ErrorMessages.Add("Choose a valid age range.");
                isAgeRangeValid = false;
            }

            return isAgeRangeValid;
        }
    }
}