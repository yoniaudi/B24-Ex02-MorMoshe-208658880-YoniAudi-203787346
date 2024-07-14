using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Features.ValidationStrategy
{
    public interface IValidationStrategy<T>
    {
        bool Validate(T data, out string errorMessage);
    }
}
