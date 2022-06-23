using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using UtilsSharp.AspNetCore;
using UtilsSharp.AspNetCore.Interceptor;
using UtilsSharp.AspNetCore.Swagger;

namespace DncHost
{
    public class Startup:AutofacStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //��ӿ���������
            services.AddControllers();
            //���swagger��չ����,���������������Ĭ�ϵ�swagger����
            AspNetCoreExtensionsConfig.SwaggerDocOptions = new SwaggerDocOptions
            {
                Enable = true,
                ProjectName = "Dnc��Ŀ",
                ProjectDescription = "Dnc��Ŀ�ӿ�",
                Groups = new List<SwaggerGroup>
                {
                    new SwaggerGroup() {GroupName = "Users", Title = "Users�ӿ�", Version = "v1.0"},
                    new SwaggerGroup() {GroupName = "Logins", Title = "Logins�ӿ�", Version = "v1.0"}
                }
            };
            //���AspNetCore��չ
            services.AddAspNetCoreExtensions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            //ע����չ
            app.UseAspNetCoreExtensions();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// ����ע��ӳ��
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            Init<AsyncInterceptor<LoggerAsyncInterceptor>>(builder);
            //Init(builder);//��aop����
            //Init<LoggerInterceptor>(builder);//��֧��ͬ�������� 
        }
    }
}
