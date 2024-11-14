using CoureTst2.Data;
using CoureTst2.Models;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add in-memory database
builder.Services.AddDbContext<PhoneNumberDbContext>(options =>
    options.UseInMemoryDatabase("PhoneNumberDB"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Seed the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PhoneNumberDbContext>();
    SeedDatabase(dbContext);
}

void SeedDatabase(PhoneNumberDbContext context)
{
    // Add Countries and CountryDetails
    var nigeria = new Country { Id = 1, CountryCode = "234", Name = "Nigeria", CountryIso = "NG" };
    nigeria.CountryDetails.AddRange(new[]
    {
        new CountryDetail { Id = 1, CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" },
        new CountryDetail { Id = 2, CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" },
        new CountryDetail { Id = 3, CountryId = 1, Operator = "9Mobile Nigeria", OperatorCode = "ETN" },
        new CountryDetail { Id = 4, CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" }
    });
    context.Countries.Add(nigeria);

    // Add other countries and details following the same structure

    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
