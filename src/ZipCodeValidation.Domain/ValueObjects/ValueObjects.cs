using System;
using System.Collections.Generic;
using System.Text;

namespace ZipCodeValidation.Domain.ValueObjects
{
    // These are immutable values e.g. ZipCode("55113") 
    public record ZipCode(string Value);
    public record Locality(string Code);
    public record State(string Code);
    public record Country(string Code);


}
