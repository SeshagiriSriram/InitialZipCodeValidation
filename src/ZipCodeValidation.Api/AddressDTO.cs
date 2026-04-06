namespace ZipCodeValidation.Api
{
    public class AddressDto
    {
        public required string ZipCode { get; set; }
        public required string Locality { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
    }

}
