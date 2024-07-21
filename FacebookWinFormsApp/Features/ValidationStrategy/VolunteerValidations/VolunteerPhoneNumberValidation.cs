using BasicFacebookFeatures.Features.Volunteering;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class VolunteerPhoneNumberValidation : IValidation<VolunteerModel>
    {
        public bool Validate(VolunteerModel i_Data, List<string> i_ErrorMessages)
        {
            bool isPhoneNumberValid = true;

            if (string.IsNullOrEmpty(i_Data.PhoneNumber) == true)
            {
                i_ErrorMessages.Add("Invalid phone number.");
                isPhoneNumberValid = false;
            }

            return isPhoneNumberValid;
        }
    }
}
