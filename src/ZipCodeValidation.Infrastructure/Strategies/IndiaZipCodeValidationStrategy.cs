using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.Exceptions;
using ZipCodeValidation.Domain.Interfaces;
using ZipCodeValidation.Domain.ValueObjects;

namespace ZipCodeValidation.Infrastructure.Strategies
{
    public class IndiaZipCodeValidationStrategy:IZipCodeValidationStrategy
    {
        public Country Country => new("India");
        public bool CanHandle(string countryCode) =>
        string.Equals(countryCode, "India", StringComparison.OrdinalIgnoreCase);

        public ValidationResult Validate(Address address)
        {
            Console.WriteLine("India Validator"); 
                return new ValidationResult(true, null);
        }
    }
}
