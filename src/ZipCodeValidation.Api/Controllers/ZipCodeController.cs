using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZipCodeValidation.Application;
using ZipCodeValidation.Domain.Entities;
using ZipCodeValidation.Domain.Exceptions;
using ZipCodeValidation.Domain.ValueObjects;

namespace ZipCodeValidation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCodeController : ControllerBase
    {
        private readonly IZipCodeValidationService _validationService;
        public ZipCodeController(IZipCodeValidationService service)
        {
            _validationService = service;
        }
        [HttpPost("validate")]
        public IActionResult Validate([FromBody] AddressDto dto)
        {
            var address = new Address(
                new ZipCode(dto.ZipCode),
                new Locality(dto.Locality),
                new State(dto.State),
                new Country(dto.Country));
            try
            {
                var result = _validationService.Validate(address);
                return Ok(new { isValid = result });
            }
            catch (DomainException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
