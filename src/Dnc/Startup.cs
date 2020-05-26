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
            //��ӿ���������
            services.AddControllers();
            //�����չ�������������������Ĭ�ϵ�swagger����
            services.AddAspNetCoreExtensions(new SwaggerDocOptions { Name = "v1", OpenApiInfo = { Title = "Dnc��Ŀ", Version = "v1", Description = "Dnc��Ŀ�ӿ�" } });
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        /// <summary>
        /// ����ע��ӳ��
        /// </summary>
        /// <param name="builder">builder</param>
        public override void ConfigureContainer(ContainerBuilder builder)
        {
            //�޼���ռ�������־
            Init(builder);
            //aop Exception������־���
            //Init<LoggerInterceptor>(builder);
        }
    }
}
