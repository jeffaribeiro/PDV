using DesafioTotvsPDV.Business.Implementacao;
using DesafioTotvsPDV.Business.Interfaces;
using DesafioTotvsPDV.Data.Context;
using DesafioTotvsPDV.Data.Persistencia;
using DesafioTotvsPDV.Data.Repositorios;
using DesafioTotvsPDV.Domain.Interfaces.Repositorios;
using DesafioTotvsPDV.Services.Implementacao;
using DesafioTotvsPDV.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DesafioTotvsPDV.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyContext, MyContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPagamentoService, PagamentoService>();
            services.AddTransient<IPagamentoBusiness, PagamentoBusiness>();
            services.AddTransient<IPagamentoRepository, PagamentoRepository>();
            services.AddTransient<IItemTrocoPagamentoRepository, ItemTrocoPagamentoRepository>();
            
            services.AddMvc();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info { Title = "DesafioTotvsPDV", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();            
            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioTotvsPDV - V1");
            });
            app.UseDeveloperExceptionPage();
        }

   }
}
