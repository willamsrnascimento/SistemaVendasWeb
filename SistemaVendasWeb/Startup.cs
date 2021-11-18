using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SistemaVendasWeb.Data;
using SistemaVendasWeb.Services;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using SistemaVendasWeb.Repository;

namespace SistemaVendasWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAntiforgery();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<SistemaVendasWebContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("SistemaVendasDB")));
            //options.UseMySql(Configuration.GetConnectionString("SistemaVendasWebContext"), builder => builder.MigrationsAssembly("SistemaVendasWeb")));


            services.AddScoped<SeedingService>();
            services.AddScoped<FuncionarioService>();
            services.AddTransient<IFuncionarioRepository, FuncionarioService>();
            services.AddTransient<IEnderecoRepository, EnderecoService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<StatusService>();
            services.AddScoped<ImagemService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
   
    }
}
