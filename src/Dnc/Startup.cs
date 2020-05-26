using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Core.Extensions;
using AspNet.Core.Extensions.Autofac;
using AspNet.Core.Extensions.Interceptor;
using AspNet.Core.Extensions.Swagger;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dnc
{
    public class Startup:AutofacStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //添加控制器服务
            services.AddControllers();
            //添加扩展服务，如果参数不填则用默认的swagger配置
            services.AddAspNetCoreExtensions(new SwaggerDocOptions { Name = "v1", OpenApiInfo = { Title = "Dnc项目", Version = "v1", Description = "Dnc项目接口" } });
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        /// <summary>
        /// 依赖注入映射
        /// </summary>
        /// <param name="builder">builder</param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            //无监控收集错误日志
            Init(builder);
            //aop Exception错误日志监控
            //Init<LoggerInterceptor>(builder);
        }
    }
}
