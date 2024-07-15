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

    public void SaveVolunteers(List<Volunteer> i_Volunteers)
    {
        Singleton<SingletonFileOperations>.Instance.SaveToFile(i_Volunteers);
    }

    public List<Volunteer> FilterVolunteersByPhoneNumber(List<Volunteer> i_Volunteers, string i_PhoneNumber)
    {
        return i_Volunteers.Where(volunteer => volunteer.PhoneNumber == i_PhoneNumber).ToList();
    }

    public Volunteer ExtractVolunteerDetails(string i_volunteerStr)
    {
        Volunteer volunteer = new Volunteer();
        string[] details = i_volunteerStr.Split(new string[] { " at ", " from ", " to ", " Phone:" }, StringSplitOptions.None);

        if (details.Length == 5)
        {
            volunteer.Subject = details[0].Trim();
            volunteer.Location = details[1].Trim();
            volunteer.StartDate = DateTime.Parse(details[2].Trim()).Date;
            volunteer.EndDate = DateTime.Parse(details[3].Trim()).Date;
            volunteer.PhoneNumber = details[4].Trim();
        }

        return volunteer;
    }

    public void RemoveVolunteer(List<Volunteer> i_Volunteer, Volunteer i_VolunteerToRemove)
    {
        i_Volunteer.Remove(i_VolunteerToRemove);
        SaveVolunteers(i_Volunteer);
    }
}