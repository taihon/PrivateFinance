using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrivateFinance.DataAccess.Account;
using PrivateFinance.DataAccess.DbImplementation.Account;
using PrivateFinance.DB;
using Swashbuckle.AspNetCore.Swagger;

namespace PrivateFinance.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<FinanceContext>(option=>
                option.UseSqlServer(Configuration.GetConnectionString("FinanceContext"))
                );


            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "Private finance management API",
                            Version = "v1",
                            Description = "API for management of private finances",
                            TermsOfService = "None",
                            License = new License { Name = "Use under MIT" },
                            Contact = new Contact { Name = "Taihon", Url = "https://taihon.github.io" }
                        });
                });
            
            // Add framework services.
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            Mapping.CreateMappings(services);

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(
                sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));



            RegisterCommandsAndQueries(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project management API v1");
                c.RoutePrefix = "api-docs";
            });
            app.UseMvc();
        }

        private void RegisterCommandsAndQueries(IServiceCollection services)
        {
            services
                .AddScoped<IAccountsListQuery, AccountsListQuery>()
                .AddScoped<IAccountQuery, AccountQuery>()

                ;
        }
    }
}
