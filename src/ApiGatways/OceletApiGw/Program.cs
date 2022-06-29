
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
var s=Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext,config)=>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
})
    .ConfigureLogging((hostingContext, loggingbuilder) =>
{

    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});
await app.UseOcelot();
app.Run();
