using BuildingBlocks.Behaviours;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

builder.Services.AddCarter();
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
    conf.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});
builder.Services.AddMarten(opt => opt.Connection(config.GetConnectionString("Database")!)).UseLightweightSessions();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

app.MapCarter();

app.Run();
