using System.Collections.Generic;

namespace BasicFacebookFeatures
{
    public class TravelBuddyModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public List<string> TraveledCountries { get; set; }
        public List<TravelPlanModel> TravelPlans { get; set; } = new List<TravelPlanModel>();
    }
}
