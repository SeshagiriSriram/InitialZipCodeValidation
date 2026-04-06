using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.Exceptions;
using ZipCodeValidation.Domain.ValueObjects; 
namespace ZipCodeValidation.Application
{
	public class ZipCodeValidationService : IZipCodeValidationService
{
    private readonly IZipCodeValidator _validator;
    public ZipCodeValidationService(IZipCodeValidator validator)
    {
        Console.WriteLine("Service Constructor called. Validator is null? " + (validator == null));
            _validator = validator;
    }
        public ValidationResult Validate(Address address)
        {
            if (address == null)
            {
                Console.WriteLine("Address is null"); 
            } 
            if(_validator==null)
            {
                Console.WriteLine("in service validate() validator is null");
            }
            return _validator.Validate(address);
    }
}

}