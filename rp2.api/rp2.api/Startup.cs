using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rp2.api.MongoModels;
using rp2.api.Singletons;

namespace rp2.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            if(env.IsDevelopment())
            {
                var databaseMongoSettings = new DatabaseMongoSettings();
                Configuration.GetSection(nameof(DatabaseMongoSettings)).Bind(databaseMongoSettings);

                Configurations.Instance.DatabaseMongoSettings = databaseMongoSettings;
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.Configure<DatabaseMongoSettings>(
            //    Configuration.GetSection(nameof(DatabaseMongoSettings)));

            //services.AddSingleton<IDatabaseMongoSettings>(sp =>
            //    sp.GetRequiredService<IOptions<DatabaseMongoSettings>>().Value);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
