using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Sociometry.Startup))]

namespace Sociometry
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddHttpClient();

            //builder.Services.AddSingleton<IMyService>((s) => {
            //    return new MyService();
            //});

            //builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
            Extend(builder);
        }

        public void Extend(IFunctionsHostBuilder builder)
        {
            //var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //// Managed Identity
            //// SRC: https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity?tabs=portal%2Chttp
            //var credential = new DefaultAzureCredential();
            ////var credential = new ManagedIdentityCredential(clientId: "3810c47f-8a58-4fba-879e-fffb8ce6e0ed");

            //// Managed Idenity and SignalR
            //// SRC: https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-howto-authorize-managed-identity

            //// SignalR
            //// SRC: https://docs.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-6.0
            //// SRC: https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-dotnet-core#add-azure-signalr-to-the-web-app
            //// CMD: dotnet add package Microsoft.Azure.SignalR
            //// var srb = builder.Services.AddSignalR();

            //// SRC: https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-howto-authorize-managed-identity#using-system-assigned-identity
            //// srb.AddAzureSignalR(option =>
            //// {
            ////     var o = builder.Configuration.GetSection("SignalR").Get<SignalROptions>();
            ////     option.Endpoints = new ServiceEndpoint[]
            ////     {
            ////         new ServiceEndpoint(new Uri(o?.EndpointUrl ?? "") , credential),
            ////     };
            //// });

            builder.Services.AddControllers();

            //builder.Services.

            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
            //});

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //// if (!app.Environment.IsDevelopment())
            //// {
            ////     app.UseExceptionHandler("/Error");
            ////     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            ////     app.UseHsts();
            //// }

            //// app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //// app.UseAuthorization();

            //app.MapRazorPages();
            ////app.MapHub<ChatHub>("/Chat");

            //app.UseAuthorization();


            //app.Run();
        }
    }
}
