using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
