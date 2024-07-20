using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacebookWrapper.ObjectModel.User;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class TravelGenderValidation : IValidation<TravelBuddyData>
    {
        public bool Validate(TravelBuddyData i_Data, List<string> i_ErrorMessages)
        {
            bool isGenderValid = true;

            if (string.IsNullOrEmpty(i_Data.Gender) == true)
            {
                i_ErrorMessages.Add("Choose a gender.");
                isGenderValid = false;
            }

            return isGenderValid;
        }
    }
}
