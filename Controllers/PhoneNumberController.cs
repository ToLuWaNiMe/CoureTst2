using CoureTst2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoureTst2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly PhoneNumberDbContext _context;

        public PhoneNumberController(PhoneNumberDbContext context)
        {
            _context = context;
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCountryByPhoneNumber(string phoneNumber)
        {
            // Extract country code from the phone number
            var countryCode = phoneNumber.Substring(0, 3);

            // Find country by country code
            var country = await _context.Countries
                .Include(c => c.CountryDetails)
                .FirstOrDefaultAsync(c => c.CountryCode == countryCode);

            if (country == null)
            {
                return NotFound(new { Message = "Country not found for the provided phone number." });
            }

            // Prepare response data
            var response = new
            {
                number = phoneNumber,
                country = new
                {
                    countryCode = country.CountryCode,
                    name = country.Name,
                    countryIso = country.CountryIso,
                    countryDetails = country.CountryDetails.Select(cd => new
                    {
                        cd.Operator,
                        cd.OperatorCode
                    })
                }
            };

            return Ok(response);
        }
    }


}
