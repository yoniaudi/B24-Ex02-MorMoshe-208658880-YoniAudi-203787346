using System.Collections.Generic;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public interface IValidation<T>
    {
        bool Validate(T i_Data, List<string> i_ErrorMessages);
    }
}
