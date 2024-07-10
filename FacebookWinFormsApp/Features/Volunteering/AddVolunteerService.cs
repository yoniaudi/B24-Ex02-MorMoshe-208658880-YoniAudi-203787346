using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;

public class AddVolunteerService
{
    public bool ValidateData(VolunteerPerson volunteerPerson, out string errorMessage)
    {
        var errorMessages = new List<string>();

        validateSubject(volunteerPerson.Subject, errorMessages);
        validateLocation(volunteerPerson.Location, errorMessages);
        validateDates(volunteerPerson.StartDate, volunteerPerson.EndDate, errorMessages);
        validatePhone(volunteerPerson.PhoneNumber, errorMessages);

        if (errorMessages.Count > 0)
        {
            errorMessage = string.Join(Environment.NewLine, errorMessages);
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    private void validateSubject(string subject, List<string> errorMessages)
    {
        if (string.IsNullOrEmpty(subject))
        {
            errorMessages.Add("Choose subject");
        }
    }

    private void validateLocation(string location, List<string> errorMessages)
    {
        if (string.IsNullOrEmpty(location))
        {
            errorMessages.Add("Choose location");
        }
    }

    private void validateDates(DateTime startAvailableDate, DateTime endAvailableDate, List<string> errorMessages)
    {
        if (startAvailableDate > endAvailableDate)
        {
            errorMessages.Add("Invalid dates");
        }
    }

    private void validatePhone(string phone, List<string> errorMessages)
    {
        if (string.IsNullOrEmpty(phone))
        {
            errorMessages.Add("Enter phone number");
        }
    }

    public void SaveVolunteerPerson(VolunteerPerson volunteerPerson)
    {
        FileOperations.SaveVolunteerPersonToFile(volunteerPerson);
    }
}
