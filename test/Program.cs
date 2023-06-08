using EventAppDataLayer;
using EventAppDataLayer.Entity;
using EventAppDataLayer.Interface;
using EventAppDataLayer.Repository;
using EventAppDataLayer.Service;
using EventAppServices.Interface;
using EventAppServices.Mapper;
using EventAppServices.Service;
using Microsoft.EntityFrameworkCore;
using RegistrationSystemDataLayer.Service;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EventsAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IParticipantRepository, ParticipantRepository>();
builder.Services.AddTransient<IParticipantInEventRepository, ParticipantInEventRepository>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IParticipantService, ParticipantService>();
builder.Services.AddTransient<IParticipantInEventService, ParticipantInEventService>();
builder.Services.AddSingleton<EventMapper, EventMapper>();
builder.Services.AddSingleton<ParticipantMapper, ParticipantMapper>();
builder.Services.AddSingleton<ParticipantInEventMapper, ParticipantInEventMapper>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:3000") // specifying the allowed origin
                            .WithMethods("GET","POST","DELETE","PUT") // defining the allowed HTTP method
                            .AllowAnyHeader(); // allowing any header to be sent
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
