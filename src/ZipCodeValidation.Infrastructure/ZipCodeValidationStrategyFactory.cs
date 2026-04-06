using System;
using System.Collections.Generic;
using System.Text;
using ZipCodeValidation.Application;
using ZipCodeValidation.Domain.Interfaces;
using ZipCodeValidation.Domain.ValueObjects;
namespace ZipCodeValidation.Infrastructure
{
    public class ZipCodeValidationStrategyFactory: IZipCodeValidationStrategyFactory
    {
        private readonly Dictionary<Country, IZipCodeValidationStrategy> _strategies;
        public ZipCodeValidationStrategyFactory(IEnumerable<IZipCodeValidationStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.Country, s => s);
        }

        public IZipCodeValidationStrategy GetStrategy(Country country)
        {
            var normalized = country.Code?.Trim().ToUpperInvariant();
             if (_strategies.TryGetValue(country, out var strategy))
            {
                return strategy;
            }
            //return _strategies.FirstOrDefault(s => s.CanHandle(normalized));
            throw new NotSupportedException($"No zip code validator found for {country}");
        }

    }
}
