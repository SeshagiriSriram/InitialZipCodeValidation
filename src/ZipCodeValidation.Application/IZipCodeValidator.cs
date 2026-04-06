using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.ValueObjects;
namespace ZipCodeValidation.Application
{
    public interface IZipCodeValidator
    {
        ValidationResult Validate(Address address);

    }
}
