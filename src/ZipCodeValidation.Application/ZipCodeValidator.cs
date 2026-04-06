using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ZipCodeValidation.Domain.ValueObjects; 
namespace ZipCodeValidation.Application
{
    using System.Diagnostics.Metrics;
    using ZipCodeValidation.Domain.Entities;
    using ZipCodeValidation.Domain.Exceptions;
    using ZipCodeValidation.Domain.Interfaces;
    public class ZipCodeValidator: IZipCodeValidator
    {
        //private readonly IZipCodeValidationStrategy _strategy;
        private readonly IEnumerable<IZipCodeValidationStrategy> _strategies;
        //public ZipCodeValidator(IZipCodeValidationStrategy strategy)
        public ZipCodeValidator(IEnumerable<IZipCodeValidationStrategy> strategies)
        {
            //Console.WriteLine("Validator Constructor called. strategy is null? " + (strategy == null));
            //_strategy = strategy;
            _strategies = strategies; 
        }
        public ValidationResult Validate(Address address)
        {
            //Console.WriteLine("Calling validate()");
            //if(_strategy==null)
            //{
            // Console.WriteLine("Strategy is null"); 
            //}
            var strategy = _strategies.FirstOrDefault(s => s.Country == address.Country);
            if (strategy == null)
                throw new DomainException($"No strategy found for country {address.Country}");
            return strategy.Validate(address);

        }

    }
}
