using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using LogisticsManagementSystem_IDAL;
using LogisticsManagementSystem_DAL;
using LogisticsManagementSystem_Common;

namespace LogisticsManagementSystem_API
{
    public class JwtConfig
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SigningKey { get; set; }
    }
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
            services.AddCors(options => options.AddPolicy("cor",
             builder =>
             {
                 builder.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                  .AllowCredentials();
             }));
            var jwtconfig = Configuration.GetSection("Jwt").Get<JwtConfig>();
            // JWT�����֤
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidIssuer = jwtconfig.Issuer,
                    ValidAudience = jwtconfig.Audience,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.SigningKey)),
                    // �������ʱ�䣬�ܵ���Чʱ��������ʱ�����jwt�Ĺ���ʱ�䣬��������ã�Ĭ����5����
                    ClockSkew = TimeSpan.FromSeconds(10)
                };
            });

            services.AddOptions().Configure<JwtConfig>(Configuration.GetSection("Jwt"));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogisticsManagementSystem_API", Version = "v1" });
                //#region swagger��JWT��֤
                //����Ȩ��С��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //��header�����token�����ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
               // #endregion
            });

            string connection = Configuration.GetConnectionString("default");
            Connection.conntction = connection;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Configuration.GetConnectionString("");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogisticsManagementSystem_API v1"));
            }
            app.UseCors("cor");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder build)
        {
            var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "LogisticsManagementSystem_DAL.dll"); 
            build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        }
    }
}
