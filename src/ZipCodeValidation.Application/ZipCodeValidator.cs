using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ZipCodeValidation.Application
{
    using ZipCodeValidation.Domain.Interfaces;
    using ZipCodeValidation.Domain.Entities; 
    public class ZipCodeValidator
    {
        private readonly IZipCodeValidationStrategy _strategy;
        public ZipCodeValidator(IZipCodeValidationStrategy strategy)
        {
            _strategy = strategy;
        }
        public void Validate(Address address)
        {
            _strategy.Validate(address);
        }

    }
}
