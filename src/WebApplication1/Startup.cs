using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Native IoC Container

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAttendeeService, AttendeeService>();
            //services.AddTransient<ISessionService, SessionService>();

            // Add framework services.
            services.AddMvc();

            // Add functionality to inject IOptions<T>.
            services.AddOptions();

            // Add our config object, so that it can be injected.
            services.Configure<Attendee>(Configuration.GetSection("AttendeeInfo"));

            // Register IConfiguration with DI system to support IConfiguration.GetValue approach
            services.AddSingleton<IConfiguration>(Configuration);
        }

        #endregion

        #region 3rd Party IoC Container

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services.AddMvc();

        //    // Add functionality to inject IOptions<T>.
        //    services.AddOptions();

        //    // Add our config object, so that it can be injected.
        //    services.Configure<Attendee>(Configuration.GetSection("AttendeeInfo"));

        //    // Register IConfiguration with DI system to support IConfiguration.GetValue approach
        //    services.AddSingleton<IConfiguration>(Configuration);
        //}

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    // Add any Autofac modules or registrations.
        //    // This is called AFTER ConfigureServices so things you
        //    // register here OVERRIDE things registered in ConfigureServices.
        //    //
        //    // You must have the call to AddAutofac in the Program.Main
        //    // method or this won't be called.
        //    builder.RegisterModule(new AutofacModule());
        //}

        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
