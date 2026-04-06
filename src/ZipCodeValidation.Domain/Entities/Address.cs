using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace ZipCodeValidation.Domain.Entities
{
    using ZipCodeValidation.Domain.ValueObjects; 
    public class Address
    {
        public ZipCode ZipCode { get; }
        public Locality Locality { get; }
        public State State { get; }
        public Country Country { get; }
        public Address(ZipCode zip, Locality locality, State state, Country country)
        {
            ZipCode = zip;
            Locality = locality;
            State = state;
            Country = country;
        }

    }
}
