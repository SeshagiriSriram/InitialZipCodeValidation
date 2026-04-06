using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ZipCodeValidation.Domain.ValueObjects; 
namespace ZipCodeValidation.Application
{
    using ZipCodeValidation.Domain.Entities; 
    using ZipCodeValidation.Domain.Interfaces;
    public class ZipCodeValidator: IZipCodeValidator
    {
        private readonly IZipCodeValidationStrategy _strategy;
        public ZipCodeValidator(IZipCodeValidationStrategy strategy)
        {
            Console.WriteLine("Validator Constructor called. strategy is null? " + (strategy == null));

            _strategy = strategy;
        }
        public ValidationResult Validate(Address address)
        {
            Console.WriteLine("Calling validate()");
            if(_strategy==null)
            {
                Console.WriteLine("Strategy is null"); 
            }
            return _strategy.Validate(address);
        }

    }
}
