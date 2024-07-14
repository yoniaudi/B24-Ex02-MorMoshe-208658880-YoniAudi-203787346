using BasicFacebookFeatures.Features.ValidationStrategy;
using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;

public class AddVolunteerService
{
    public IValidationStrategy<VolunteerPerson> ValidationStrategy { get; set; }

    public AddVolunteerService()
    {
        ValidationStrategy = new AddVolunteerValidationStrategy();
    }

    public bool ValidateData(VolunteerPerson volunteerPerson, out string errorMessage)
    {
        return ValidationStrategy.Validate(volunteerPerson, out errorMessage);
    }

    public void SaveVolunteerPerson(VolunteerPerson volunteerPerson)
    {
        Singleton<SingletonFileOperations>.Instance.SaveVolunteerPersonToFile(volunteerPerson);
    }
}
