using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class VolunteerCategoryValidation : IValidation<VolunteerModel>
    {
        public bool Validate(VolunteerModel i_Data, List<string> i_ErrorMessages)
        {
            bool isVolunteerCategoryValid = true;

            if (string.IsNullOrEmpty(i_Data.Subject) == true)
            {
                i_ErrorMessages.Add("Choose a subject.");
                isVolunteerCategoryValid = false;
            }

            return isVolunteerCategoryValid;
        }
    }
}
