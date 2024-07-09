using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveVolunteerService
{
    public List<VolunteerPerson> LoadVolunteers()
    {
        return FileOperations.LoadFromFile();
    }

    public void SaveVolunteers(List<VolunteerPerson> volunteerPeople)
    {
        FileOperations.SaveToFile(volunteerPeople);
    }

    public List<VolunteerPerson> FilterVolunteersByPhoneNumber(List<VolunteerPerson> volunteerPeople, string phoneNumber)
    {
        return volunteerPeople.Where(v => v.PhoneNumber == phoneNumber).ToList();
    }

    public VolunteerPerson ExtractVolunteerDetails(string volunteerString)
    {
        VolunteerPerson details = new VolunteerPerson();
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

    public void RemoveVolunteer(List<VolunteerPerson> volunteerPeople, VolunteerPerson volunteerToRemove)
    {
        volunteerPeople.Remove(volunteerToRemove);
        SaveVolunteers(volunteerPeople);
    }
}
