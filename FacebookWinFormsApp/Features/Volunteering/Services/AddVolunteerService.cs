using BasicFacebookFeatures.Features.ValidationStrategy;
using BasicFacebookFeatures.Features.Volunteering;
using System;
using System.Collections.Generic;

public class AddVolunteerService
{
    public IValidation<VolunteerModel> Validations { get; set; }

    public bool DataValidation(VolunteerModel i_Volunteer, out string o_ErrorMessage)
    {
        List<string> errorMessages = new List<string>();
        bool isDataValid = true;

        Validations = new VolunteerCategoryValidation();
        Validations.Validate(i_Volunteer, errorMessages);
        Validations = new VolunteerLocationValidation();
        Validations.Validate(i_Volunteer, errorMessages);
        Validations = new VolunteerDateValidation();
        Validations.Validate(i_Volunteer, errorMessages);
        Validations = new VolunteerPhoneNumberValidation();
        Validations.Validate(i_Volunteer, errorMessages);

        if (errorMessages.Count > 0)
        {
            o_ErrorMessage = string.Join(Environment.NewLine, errorMessages);
            isDataValid = false;
        }
        else
        {
            o_ErrorMessage = string.Empty;
        }

        return isDataValid;
    }

    public void SaveVolunteerPerson(VolunteerModel i_Volunteer)
    {
        Singleton<SingletonFileOperations>.Instance.SaveVolunteerPersonToFile(i_Volunteer);
    }
}