using BasicFacebookFeatures.Features.Volunteering;
using System.Collections.Generic;

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