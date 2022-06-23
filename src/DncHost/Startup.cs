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
            //添加控制器服务
            services.AddControllers();
            //添加swagger扩展服务,如果参数不填则用默认的swagger配置
            AspNetCoreExtensionsConfig.SwaggerDocOptions = new SwaggerDocOptions
            {
                Enable = true,
                ProjectName = "Dnc项目",
                ProjectDescription = "Dnc项目接口",
                Groups = new List<SwaggerGroup>
                {
                    new SwaggerGroup() {GroupName = "Users", Title = "Users接口", Version = "v1.0"},
                    new SwaggerGroup() {GroupName = "Logins", Title = "Logins接口", Version = "v1.0"}
                }
            };
            //添加AspNetCore扩展
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
            //注册扩展
            app.UseAspNetCoreExtensions();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// 依赖注入映射
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            Init<AsyncInterceptor<LoggerAsyncInterceptor>>(builder);
            //Init(builder);//无aop拦截
            //Init<LoggerInterceptor>(builder);//仅支持同步的拦截 
        }
    }
}
