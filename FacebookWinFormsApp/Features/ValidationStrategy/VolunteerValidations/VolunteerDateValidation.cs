using BasicFacebookFeatures.Features.Volunteering;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class VolunteerDateValidation : IValidation<VolunteerModel>
    {
        public bool Validate(VolunteerModel i_Data, List<string> i_ErrorMessages)
        {
            bool isDateValid = true;

            if (i_Data.StartDate > i_Data.EndDate)
            {
                i_ErrorMessages.Add("Invalid dates.");
                isDateValid = false;
            }

            return isDateValid;
        }
    }
}