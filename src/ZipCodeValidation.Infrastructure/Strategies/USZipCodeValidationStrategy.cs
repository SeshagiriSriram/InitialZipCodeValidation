using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.Exceptions;
using ZipCodeValidation.Domain.Interfaces;
using ZipCodeValidation.Domain.ValueObjects;

namespace ZipCodeValidation.Infrastructure.Strategies
{
    public class USZipCodeValidationStrategy:IZipCodeValidationStrategy
    {
        public Country Country => new("US");

        public ValidationResult Validate(Address address)
        {
            // Example: 55113 belongs to MN, not CA 
            // This is where you will validate based on length, chars and/or mapping 
            if (address.ZipCode.Value == "55113" &&
           address.Locality.Code == "Roseville" &&
           address.State.Code == "CA" && address.Country.Code == "US")
            {
                //throw new DomainException("Zip code does not match locality/state.");
                return new ValidationResult(false, "Zip code does not match locality/state.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
