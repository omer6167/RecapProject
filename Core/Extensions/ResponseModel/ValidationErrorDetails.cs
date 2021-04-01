using System.Collections.Generic;
using FluentValidation.Results;

namespace Core.Extensions.ResponseModel
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidateErrors { get; set; }
    }
}