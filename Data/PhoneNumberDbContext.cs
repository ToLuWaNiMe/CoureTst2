using CoureTst2.Models;
using Microsoft.EntityFrameworkCore;

namespace CoureTst2.Data
{
    public class PhoneNumberDbContext : DbContext
    {
        public PhoneNumberDbContext(DbContextOptions<PhoneNumberDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryDetail> CountryDetails { get; set; }
    }

}
