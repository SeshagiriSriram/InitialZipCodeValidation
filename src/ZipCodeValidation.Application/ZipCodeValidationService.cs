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
            _validator = validator;
    }
        public ValidationResult Validate(Address address)
        {
            return _validator.Validate(address);
    }
}

}