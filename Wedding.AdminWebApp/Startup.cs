using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wedding.AdminWebApp.Authorisation;
using Wedding.Application.Core;
using Wedding.Application.Core.Invites;
using Wedding.Application.Core.Meals;
using Wedding.Application.Core.Rsvps;
using Wedding.Common.Core;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.ReferenceDatas;
using Wedding.Persistence.Core.Contexts;
using Wedding.Persistence.Core.Repositories;

namespace Wedding.AdminWebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add framework services.
            serviceCollection.AddMvc();
            serviceCollection.AddSingleton(Configuration);
            serviceCollection.AddSingleton<IConfigurationManager, ConfigurationManager>();
            IConfigurationManager configurationManager =
                serviceCollection.BuildServiceProvider().GetService<IConfigurationManager>();
            string connectionString = configurationManager.GetSetting("SqlConnectionString");

            serviceCollection.AddScoped<ISession, Session>();
            serviceCollection.AddScoped<IInviteRepository, InviteRepository>();
            serviceCollection.AddScoped<IDessertChoiceRepository, DessertChoiceRepository>();
            serviceCollection.AddScoped<IMainChoiceRepository, MainChoiceRepository>();
            serviceCollection.AddScoped<IStarterChoiceRepository, StarterChoiceRepository>();
            serviceCollection.AddScoped<IWeddingEventRepository, WeddingEventRepository>();

            serviceCollection.AddScoped<IMealValidator, MealValidator>();

            serviceCollection.AddScoped<IInviteFactory, InviteFactory>();

            // App Project
            serviceCollection.AddScoped<ISessionFactory, SessionFactory>();
            serviceCollection.AddScoped<IInviteService, InviteService>();
            serviceCollection.AddScoped<IRsvpService, RsvpService>();
            serviceCollection.AddScoped<IMealChoiceService, MealChoiceService>();

            serviceCollection
                .AddDbContext<WeddingDbContext>(options => options.UseSqlServer(connectionString))
                .AddDbContext<ApplicationUserDbContext>(options => options.UseSqlServer(connectionString));

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationUserDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            applicationBuilder.UseDefaultFiles();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseMyIdentity();
            applicationBuilder.UseMvcWithDefaultRoute();
        }
    }
}
