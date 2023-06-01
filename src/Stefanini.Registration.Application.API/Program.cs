using AutoMapper;
using Stefanini.Registration.Business.Mappers;
using Stefanini.Registration.Data;
using Stefanini.Registration.Business.interfaces;
using Stefanini.Registration.Business.Services;
using Stefanini.Registration.Domain.Interfaces;
using Stefanini.Registration.Data.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Stefanini.Registration.Domain.Dtos;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StefaniniRegistration");
var currDir = Environment.CurrentDirectory;
string parsedConnectionString = connectionString!.Replace("{AppDirectory}", currDir.Replace("src\\Stefanini.Registration.Application.API", ""));

builder.Services.AddSqlite<StefaniniRegistrationContext>(parsedConnectionString);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

IMapper mapper = new MapperConfiguration(mc =>
{
    // Add AutoMapper Profiles here.
    mc.AddProfile(new LocationProfile());
    mc.AddProfile(new RegistrationProfile());
    mc.AddProfile(new EventProfile());
}).CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<ILocationRepository, LocationRepository>();
builder.Services.AddTransient<ILocationService, LocationService>();

builder.Services.AddTransient<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();

builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IEventService, EventService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
