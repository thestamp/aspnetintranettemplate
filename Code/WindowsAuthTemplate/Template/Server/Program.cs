using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.IISIntegration;
using Template.User.Server.CoreServer;


namespace Template.User.Server;
//Currently, as of nswag 13.14.3, nswag.msbuild doesn't support the minimal program code structure. To use this, you will need to use the following program.cs code below

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

//nswag needs old style for now
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddOpenApiDocument();
        services.AddAuthentication(IISDefaults.AuthenticationScheme);

        var serverAddress = Configuration.GetSection("AppOptions")["ServerBaseAddress"];

        services.AddScoped(sp => new CoreServerApiClient(serverAddress, new HttpClient { BaseAddress = new Uri(serverAddress) }));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });

    }
}