var builder = WebApplication.CreateBuilder(args);}

IConfiguration config = builder.Configuration;

builder.Services.AddCarter();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(opt => opt.Connection(config.GetConnectionString("Database")!)).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

app.Run();
