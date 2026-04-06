using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Domain.Interfaces;
using ZipCodeValidation.Domain.ValueObjects;

namespace ZipCodeValidation.Application
{
    public interface IZipCodeValidationStrategyFactory
    {
        IZipCodeValidationStrategy GetStrategy(Country country);
    }
}
