using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServiceClients;
using Template.Client;
using Template.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new UserServerApiClient(builder.HostEnvironment.BaseAddress, new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }));

//because the WeatherForecastService constructor parameters are previously DI'd objects, DI can handle the parameters for us.
builder.Services.AddScoped<WeatherForecastService>();

await builder.Build().RunAsync();
