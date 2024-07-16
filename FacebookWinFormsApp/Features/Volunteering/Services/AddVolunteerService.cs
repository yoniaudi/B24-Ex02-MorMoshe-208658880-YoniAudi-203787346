using BasicFacebookFeatures.Features.ValidationStrategy;
using BasicFacebookFeatures.Features.Volunteering;

public class AddVolunteerService
{
    public IValidationStrategy<VolunteerModel> ValidationStrategy { get; set; }

    public AddVolunteerService()
    {
        ValidationStrategy = new AddVolunteerValidationStrategy();
    }

    public bool ValidateData(VolunteerModel i_Volunteer, out string o_ErrorMessage)
    {
        return ValidationStrategy.Validate(i_Volunteer, out o_ErrorMessage);
    }

    public void SaveVolunteerPerson(VolunteerModel i_Volunteer)
    {
        Singleton<SingletonFileOperations>.Instance.SaveVolunteerPersonToFile(i_Volunteer);
    }
}