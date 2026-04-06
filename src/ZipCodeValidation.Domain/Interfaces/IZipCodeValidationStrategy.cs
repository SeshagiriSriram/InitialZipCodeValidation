using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.ValueObjects; 
namespace ZipCodeValidation.Domain.Interfaces
{
    public interface IZipCodeValidationStrategy
    {
        ValidationResult Validate(Address address); // Step #1
    }
}
