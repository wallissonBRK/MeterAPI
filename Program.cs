using MeterAPI.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder
    .AddArchitectures()
    .AddServices()
    .AddToken();
    //.UseSerilog();


var app = builder.Build();

app.UseArchitectures();
app.MapEndpoints();

app.Run();