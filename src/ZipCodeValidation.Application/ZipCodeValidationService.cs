using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.Exceptions;

namespace ZipCodeValidation.Application
{
    public class ZipCodeValidationService: IZipCodeValidationService
    {
        private readonly ZipCodeValidator _validator;
        public ZipCodeValidationService(ZipCodeValidator validator)
        {
            _validator = validator;
        }
        public bool Validate(Address address)
        {
            try
            {
                _validator.Validate(address);
                return true;
            }
            catch (DomainException ex)
            {

                throw; // Bubble up to API
            }
        }


    }
}
