using System;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public class Volunteer
    {
        public string Subject { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            string personFormat = string.Format($"{this.Subject} at {this.Location} from {this.StartDate.ToShortDateString()} to {this.EndDate.ToShortDateString()} Phone:{this.PhoneNumber}");

            return personFormat;
        }
    }
}
