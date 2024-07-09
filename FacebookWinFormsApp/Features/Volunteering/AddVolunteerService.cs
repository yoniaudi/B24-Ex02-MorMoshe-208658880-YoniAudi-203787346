using BasicFacebookFeatures.Features.Volunteering;
using System;

public class AddVolunteerService
{
    public bool ValidateData(string subject, string location, DateTime startAvailableDate, DateTime endAvailableDate, string phone, out string errorMessage)
    {
        if (string.IsNullOrEmpty(subject))
        {
            errorMessage = "Choose subject";
            return false;
        }

        if (string.IsNullOrEmpty(location))
        {
            errorMessage = "Choose location";
            return false;
        }

        if (startAvailableDate > endAvailableDate)
        {
            errorMessage = "Invalid dates";
            return false;
        }

        if (string.IsNullOrEmpty(phone))
        {
            errorMessage = "Enter phone number";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    public void SaveVolunteerPerson(VolunteerPerson volunteerPerson)
    {
        FileOperations.SaveVolunteerPersonToFile(volunteerPerson);
    }
}
