using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveVolunteerService
{
    public List<Volunteer> LoadVolunteers()
    {
        return Singleton<SingletonFileOperations>.Instance.LoadFromFile();
    }

    public void SaveVolunteers(List<Volunteer> volunteerPeople)
    {
        Singleton<SingletonFileOperations>.Instance.SaveToFile(volunteerPeople);
    }

    public List<Volunteer> FilterVolunteersByPhoneNumber(List<Volunteer> volunteerPeople, string phoneNumber)
    {
        return volunteerPeople.Where(v => v.PhoneNumber == phoneNumber).ToList();
    }

    public Volunteer ExtractVolunteerDetails(string volunteerString)
    {
        Volunteer details = new Volunteer();
        string[] parts = volunteerString.Split(new string[] { " at ", " from ", " to ", " Phone:" }, StringSplitOptions.None);

        if (parts.Length == 5)
        {
            details.Subject = parts[0].Trim();
            details.Location = parts[1].Trim();
            details.StartDate = DateTime.Parse(parts[2].Trim()).Date;
            details.EndDate = DateTime.Parse(parts[3].Trim()).Date;
            details.PhoneNumber = parts[4].Trim();
        }

        return details;
    }

    public void RemoveVolunteer(List<Volunteer> volunteerPeople, Volunteer volunteerToRemove)
    {
        volunteerPeople.Remove(volunteerToRemove);
        SaveVolunteers(volunteerPeople);
    }
}
