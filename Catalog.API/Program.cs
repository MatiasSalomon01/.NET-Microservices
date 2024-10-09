var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

var assembly = typeof(Program).Assembly;
var dbConnectionString = config.GetConnectionString("Database")!;

builder.Services.AddCarter();
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(assembly);
    conf.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    conf.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddMarten(opt => opt.Connection(dbConnectionString)).UseLightweightSessions();
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks().AddNpgSql(dbConnectionString);

if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

var app = builder.Build();

app.UseExceptionHandler(x => { });
app.MapCarter();
app.UseHealthChecks("/health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

app.Run();
