using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;

namespace ZipCodeValidation.Domain.Interfaces
{
    public interface IZipCodeValidationStrategy
    {
        void Validate(Address address); // Step #1
    }
}
