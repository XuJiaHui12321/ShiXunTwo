using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.Common.Filter;
using Serilog.Extensions.Logging.File;
using Microsoft.IdentityModel.Tokens;
using TMS.Common.JWT;
using Swashbuckle.AspNetCore.Filters;
using TMS.Common.Redis;

namespace TMS.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //public void ConfigureContainer(ContainerBuilder build)
        //{
        //    var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS.Repository.dll"); //DDal.dll是依赖注入的层
        //    build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        //}

        //This method gets called by the runtime.Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
             #region JWT配置
              services.AddAuthentication(options => {
                     //认证middleware配置
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 }).AddJwtBearer(options => {
                      //主要是jwt  token参数设置
                 options.TokenValidationParameters = new TokenValidationParameters {
                     //颁发者
                     ValidateIssuer = true,
                     ValidIssuer = Configuration["JwtSetting:Issuer"],
                     //被授权者
                     ValidateAudience = true,
                     ValidAudience = Configuration["JwtSetting:Audience"],
                     //秘钥（解密）
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSetting:SecretKey"])),
                     //是否验证失效时间【使用当前时间与Token的Claims中NotBefore和Expires对比】
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.FromMinutes(5)//允许的服务器时间偏量【5分钟】
                 };
                  });

            #endregion  ConfigureServices配置

            #region 注册jwt中间件
             services.AddTransient<JWTService>(); 
            #endregion


            #region SQL注入
            //控制器上加SQL注入过滤器
            //services.AddControllers(options =>
            //{
            //    options.Filters.Add<CustomSQLInjectFilter>();
            //});
            services.AddControllers();
            #endregion

            #region 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMS.API", Version = "v1" });
                // 为 Swagger 设置xml文档注释路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);

                #region swagger用JWT验证
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",// t默认的参数名称
                    In = ParameterLocation.Header,// t默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion

            });
            #endregion

            #region 跨域
            //添加cors 服务 配置跨域来处理
            services.AddCors(c => {
                c.AddPolicy("AllRequests", policy => {
                    policy
           .WithOrigins("http://192.168.31.231:8080", "http://192.168.31.231:8081")
           .AllowAnyMethod()
           .AllowAnyHeader();

                    

                });

            }    
            );
            #endregion


            #region 数据库连接
            DbFactory.DbConString = Configuration.GetConnectionString("MySql");
            #endregion

            #region  Redis
            //redis缓存
            var section = Configuration.GetSection("Redis:Default");
            //连接字符串
            //string _connectionString = section.GetSection("Connection").Value;
            string _connectionString = DbFactory.DbConString;
            //实例名称
            string _instanceName = section.GetSection("InstanceName").Value;
            //默认数据库 
            int _defaultDB = int.Parse(section.GetSection("DefaultDB").Value ?? "0");
            services.AddSingleton(new RedisHelper(_connectionString, _instanceName, _defaultDB));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion

            services.AddControllers(options =>
            {
                options.Filters.Add(new CustomerExceptionFilter());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//异常处理：对于开发模式，一旦报错就跳转到错误堆栈页面
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS.API v1"));
            }

            app.UseCors("AllRequests");

            #region 启用JWT(添加认证中间件【必须在授权前面添加】)
            app.UseAuthentication();
            #endregion

            #region 授权中间件
            app.UseAuthorization();
            #endregion

            #region  管道异常处理
            app.UseExceptionMiddleware();
            #endregion

            #region Nlog
            //AddFile()方法是Serilog.Extensions.Logging.File中提供的扩展方法，用于将日志写入文件中
            loggerFactory.AddFile("Logs/log{Date}.txt");
            #endregion

         


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        /// <summary>
        /// 自动依赖注入
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            string bllFilePath = Path.Combine(AppContext.BaseDirectory, "TMS.Repository.dll");
            builder.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        }




    }
}
