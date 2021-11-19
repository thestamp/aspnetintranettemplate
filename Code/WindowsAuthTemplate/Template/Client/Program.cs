using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Template.User.Client;
using Template.User.Client.Services;
using Template.User.Client.UserServer;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new WeatherForecastApiClient(builder.HostEnvironment.BaseAddress, new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }));
builder.Services.AddScoped(sp => new FutureWeatherForecastApiClient(builder.HostEnvironment.BaseAddress, new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }));

//because the WeatherForecastService constructor parameters are previously DI'd objects, DI can handle the parameters for us.
builder.Services.AddScoped<WeatherForecastService>();

await builder.Build().RunAsync();
