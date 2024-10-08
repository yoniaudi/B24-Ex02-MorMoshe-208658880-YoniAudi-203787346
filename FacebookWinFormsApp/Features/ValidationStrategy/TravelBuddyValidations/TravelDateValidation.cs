﻿using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public class TravelDateValidation : IValidation<TravelBuddyData>
    {
        public bool Validate(TravelBuddyData i_Data, List<string> i_ErrorMessages)
        {
            bool isTravelDateValid = true;

            if (string.IsNullOrEmpty(i_Data.ArrivalDate) == true || string.IsNullOrEmpty(i_Data.DepartureDate) == true ||
                DateTime.Parse(i_Data.DepartureDate) < DateTime.Parse(i_Data.ArrivalDate))
            {
                i_ErrorMessages.Add("Invalid Dates.");
                isTravelDateValid = false;
            }

            return isTravelDateValid;
        }
    }
}