using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class VolunteerLocationValidation : IValidation<VolunteerModel>
    {
        public bool Validate(VolunteerModel i_Data, List<string> i_ErrorMessages)
        {
            bool isLocationValid = true;

            if (string.IsNullOrEmpty(i_Data.Location) == true)
            {
                i_ErrorMessages.Add("Choose a location.");
                isLocationValid = false;
            }

            return isLocationValid;
        }
    }
}
