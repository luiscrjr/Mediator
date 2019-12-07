using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Services.API.Infra;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Services.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //habilitando o MediatR em modo de injeção de dependência
            services.AddMediatR(typeof(Startup));

            //habilitando o Automapper em modo de injeção de dependência
            services.AddAutoMapper(typeof(Startup));

            //injeção de dependencia para o repositório
            services.AddSingleton<IProdutoRepository, ProdutoRepository>();

            //configuração do swagger
            services.AddSwaggerGen(
               swagger =>
               {
                   swagger.SwaggerDoc("v1",
                       new Info
                       {
                           Title = "API de controle de Produtos",
                           Version = "v1",
                           Description = "Projeto desenvolvido em Asp.Net CORE com MediatR"
                       });
               }
               );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //configuração do swagger
            app.UseSwagger();
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                }
                );

            app.UseMvc();
        }
    }
}
