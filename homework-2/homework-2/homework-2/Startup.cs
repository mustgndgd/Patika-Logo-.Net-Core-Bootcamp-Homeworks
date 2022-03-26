using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; 
using homework_2.Middlewares;
using homework_2.SwaggerHelper;

namespace homework_2
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AddDefaultKeyHeaderParameter>(); // Versiyon kontrolü için swagger a appversion giriþi eklendi
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "homework_2", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "homework_2 v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseAppVersionMiddleware();  //Middleware kullanýmý yapýldý

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
