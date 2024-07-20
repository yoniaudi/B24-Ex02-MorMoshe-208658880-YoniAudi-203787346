using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveVolunteerService
{
    public List<VolunteerModel> LoadVolunteers()
    {
        return Singleton<SingletonFileOperations>.Instance.LoadFromFile();
    }

    public void SaveVolunteers(List<VolunteerModel> i_Volunteers)
    {
        Singleton<SingletonFileOperations>.Instance.SaveToFile(i_Volunteers);
    }

    public List<VolunteerModel> FilterVolunteersByPhoneNumber(List<VolunteerModel> i_Volunteers, string i_PhoneNumber)
    {
        return i_Volunteers.Where(volunteer => volunteer.PhoneNumber == i_PhoneNumber).ToList();
    }

    public VolunteerModel ExtractVolunteerDetails(string i_volunteerStr)
    {
        VolunteerModel volunteer = new VolunteerModel();
        string[] details = i_volunteerStr.Split(new string[] { " at ", " from ", " to ", " Phone:" }, StringSplitOptions.None);
        const int numberOfDetails = 5;

        if (details.Length == numberOfDetails)
        {
            volunteer.Subject = details[0].Trim();
            volunteer.Location = details[1].Trim();
            volunteer.StartDate = DateTime.Parse(details[2].Trim()).Date;
            volunteer.EndDate = DateTime.Parse(details[3].Trim()).Date;
            volunteer.PhoneNumber = details[4].Trim();
        }

        return volunteer;
    }

    public void RemoveVolunteer(List<VolunteerModel> i_Volunteer, VolunteerModel i_VolunteerToRemove)
    {
        i_Volunteer.Remove(i_VolunteerToRemove);
        SaveVolunteers(i_Volunteer);
    }
}