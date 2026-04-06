using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Entities;

namespace ZipCodeValidation.Application
{
    public  interface IZipCodeValidationService
    {
        public bool Validate(Address address); 
    }
}
