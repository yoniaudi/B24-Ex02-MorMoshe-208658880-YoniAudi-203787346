using BasicFacebookFeatures.Features.ValidationStrategy;
using BasicFacebookFeatures.Features.Volunteering;

public class AddVolunteerService
{
    public IValidationStrategy<VolunteerPerson> ValidationStrategy { get; set; }

    public AddVolunteerService()
    {
        ValidationStrategy = new AddVolunteerValidationStrategy();
    }

    public bool ValidateData(VolunteerPerson i_VolunteerPerson, out string o_ErrorMessage)
    {
        return ValidationStrategy.Validate(i_VolunteerPerson, out o_ErrorMessage);
    }

    public void SaveVolunteerPerson(VolunteerPerson i_VolunteerPerson)
    {
        Singleton<SingletonFileOperations>.Instance.SaveVolunteerPersonToFile(i_VolunteerPerson);
    }
}