using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public List<string> Errors = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
           foreach (var error in validationResult.Errors) 
            { 
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
