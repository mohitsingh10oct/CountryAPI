using CountryAPI.Interfaces;
using CountryAPI.Model;
using CountryAPI.Repository;
using CountryAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection stirn not foumnd");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionstring));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//IConfiguration configration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json")
//.Build();

//var mongoclient = new MongoClient(configration.GetConnectionString("MongoDb"));

//builder.Services.AddSingleton<IMongoClient>(mongoclient);
//builder.Services.AddScoped<ICountrieservice, Countrieservice>();

builder.Services.AddScoped<ICountrieservice, Countrieservice>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
