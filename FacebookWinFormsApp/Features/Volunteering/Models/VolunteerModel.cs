using System;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public class VolunteerModel
    {
        public string Subject { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            string personFormat = string.Format(@"{0} at {1} from {2} to {3} Phone:{4}",
                this.Subject, this.Location, this.StartDate.ToShortDateString(), this.EndDate.ToShortDateString(), this.PhoneNumber);

            return personFormat;
        }
    }
}