using BYTEBaba.Repository.SqlServer;
using BYTEBaba.Services.Factory;
using BYTEBaba.Services.FileSystem;
using BYTEBaba.Services.SqlServer;
using BYTEBaba.SqlServer;
using BYTEBaba.Web.Components;
using BYTEBabas.Web.Logger;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

namespace BYTEBaba.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddDbContext<SqlServerDbContext>(options =>
            {
                //  options.UseSqlServer(builder.Configuration.GetConnectionString("LOCAL_DB_CONNECTION_STRING"), config => config.EnableRetryOnFailure(maxRetryCount: 9, maxRetryDelay: TimeSpan.FromSeconds(30), null));
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB_CONNECTION_STRING"), config => config.EnableRetryOnFailure(maxRetryCount: 9, maxRetryDelay: TimeSpan.FromSeconds(30), null));


            }, ServiceLifetime.Transient);
            builder.Services.AddTransient(typeof(ISQLServer<>), typeof(SQLServer<>));
            builder.Services.AddTransient(typeof(ISQLServerService<>), typeof(SQLServerService<>));
            builder.Services.AddTransient<ISQLServerServiceFactory, SQLServerServiceFactory>();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                 .AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });

            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<FileSystemService>(proveder=>new FileSystemService(builder.Configuration.GetValue<string>("BOOK_SELF_PATH")));
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton<LoggingConfiguration>();
            builder.Logging.ClearProviders();
            // LoggingConfiguration.ConfigureLogging(builder.Configuration);          
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetValue<string>("SYNCFUSION_LICENSE_KEY"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
          
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
