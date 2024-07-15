namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public interface IValidationStrategy<T>
    {
        bool Validate(T i_Data, out string o_ErrorMessage);
    }
}
