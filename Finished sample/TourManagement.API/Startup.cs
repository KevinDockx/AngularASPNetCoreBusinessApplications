using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using TourManagement.API.Authorization;
using TourManagement.API.Services;

namespace TourManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserMustBeAdministrator", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.RequireRole("Administrator");
                });
                options.AddPolicy(
                   "UserMustBeTourManager",
                   policyBuilder =>
                   {
                       policyBuilder.RequireAuthenticatedUser();
                       policyBuilder.AddRequirements(
                         new UserMustBeTourManagerRequirement("Administrator"));
                   });
            });

            services.AddScoped<IAuthorizationHandler, UserMustBeTourManagerRequirementHandler>();

            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

                var jsonOutputFormatter = setupAction.OutputFormatters
                   .OfType<JsonOutputFormatter>().FirstOrDefault();

                if (jsonOutputFormatter != null)
                {
                    jsonOutputFormatter.SupportedMediaTypes
                   .Add("application/vnd.marvin.tour+json");
                    jsonOutputFormatter.SupportedMediaTypes
                   .Add("application/vnd.marvin.tourwithestimatedprofits+json");
                    jsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.marvin.tourwithshows+json");
                    jsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.marvin.tourwithestimatedprofitsandshows+json");
                    jsonOutputFormatter.SupportedMediaTypes
                   .Add("application/vnd.marvin.showcollection+json");
                }

                var jsonInputFormatter = setupAction.InputFormatters
                   .OfType<JsonInputFormatter>().FirstOrDefault();
                if (jsonInputFormatter != null)
                {
                    jsonInputFormatter.SupportedMediaTypes
                   .Add("application/vnd.marvin.tourforcreation+json");
                    jsonInputFormatter.SupportedMediaTypes
                   .Add("application/vnd.marvin.tourwithmanagerforcreation+json");
                    jsonInputFormatter.SupportedMediaTypes
                   .Add("application/vnd.marvin.tourwithshowsforcreation+json");
                    jsonInputFormatter.SupportedMediaTypes
                    .Add("application/vnd.marvin.tourwithmanagerandshowsforcreation+json");
                    jsonInputFormatter.SupportedMediaTypes
                    .Add("application/vnd.marvin.showcollectionforcreation+json");
                    jsonInputFormatter.SupportedMediaTypes
                    .Add("application/json-patch+json");
                }

            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            });

            // Configure CORS so the API allows requests from JavaScript.  
            // For demo purposes, all origins/headers/methods are allowed.  
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            // register the DbContext on the container, getting the connection string from
            // appsettings (note: use this during development; in a production environment,
            // it's better to store the connection string in an environment variable)
            var connectionString = Configuration["ConnectionStrings:TourManagementDB"];
            services.AddDbContext<TourManagementContext>(o => o.UseSqlServer(connectionString));

            // register the repository
            services.AddScoped<ITourManagementRepository, TourManagementRepository>();

            // register an IHttpContextAccessor so we can access the current
            // HttpContext in services by injecting it
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // register the user info service
            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44398";
                    options.ApiName = "tourmanagementapi";
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Entities.Tour, Dtos.Tour>()
                    .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name));

                config.CreateMap<Entities.Tour, Dtos.TourWithEstimatedProfits>()
                   .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name));

                config.CreateMap<Entities.Band, Dtos.Band>();
                config.CreateMap<Entities.Manager, Dtos.Manager>();
                config.CreateMap<Entities.Show, Dtos.Show>();

                config.CreateMap<Dtos.TourForCreation, Entities.Tour>();
                config.CreateMap<Dtos.TourWithManagerForCreation, Entities.Tour>();

                config.CreateMap<Entities.Tour, Dtos.TourWithShows>()
                   .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name));

                config.CreateMap<Entities.Tour, Dtos.TourWithEstimatedProfitsAndShows>()
                    .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name));

                config.CreateMap<Dtos.TourWithShowsForCreation, Entities.Tour>();
                config.CreateMap<Dtos.TourWithManagerAndShowsForCreation, Entities.Tour>();
                config.CreateMap<Dtos.ShowForCreation, Entities.Show>();

                config.CreateMap<Entities.Tour, Dtos.TourForUpdate>().ReverseMap();

            });

            // Enable CORS
            app.UseCors("AllowAllOriginsHeadersAndMethods");

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
