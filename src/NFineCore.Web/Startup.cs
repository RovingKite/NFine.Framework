using AutoMapper;
using Hangfire;
using Hangfire.RecurringJobExtensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NFineCore.EntityFramework;
using NFineCore.Service;
using NFineCore.Service.SystemManage;
using NFineCore.Support;
using NFineCore.Web.Filters;
using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.RegisterServices;
using SharpRepository.Ioc.Microsoft.DependencyInjection;
using System;

namespace NFineCore.Web
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddStaticHttpContextAccessor();
            //services.AddDistributedRedisCache(options => { options.Configuration = "localhost"; options.InstanceName = "NFineCore"; });
            services.AddDistributedRedisCache(options => {
                options.Configuration = Configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "NFineCore";
            });
            services.AddDistributedMemoryCache();//启用session之前必须先添加内存
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(7200);//Session过期时间为1小时(60*60)
            });
            services.AddAutoMapper();
            // 添加Cookie服务
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => false;     //这里改成false
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddMvc(option =>
            {
                option.Filters.Add(new LoginAuthFilter());
                //option.Filters.Add(new OperateLogFilter());
            });

            //注入Hangfire服务
            services.AddHangfire(configuration => {
                configuration.UseRedisStorage(Configuration.GetConnectionString("HangfireConnection"));
                configuration.UseRecurringJob("recurringjob.json");
                configuration.UseRecurringJob(typeof(RecurringJobService));
                configuration.UseDefaultActivator();
            });

            #region 注入业务服务类
            //这里可以通过反射的方式批量注入，待优化。
            services.AddTransient(typeof(AreaService));            
            services.AddTransient(typeof(DictItemService));
            services.AddTransient(typeof(DictService));
            services.AddTransient(typeof(PositionService));
            services.AddTransient(typeof(LoginLogService));
            services.AddTransient(typeof(OperateLogService));
            services.AddTransient(typeof(OrganizeService));
            services.AddTransient(typeof(PermissionService));
            services.AddTransient(typeof(ResourceService));
            services.AddTransient(typeof(RoleService));
            services.AddTransient(typeof(UserService));
            services.AddScoped<IAttachService, AttachService>();
            #endregion

            services.AddSenparcGlobalServices(Configuration)//Senparc.CO2NET 全局注册
                    .AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册（如果使用Senparc.Weixin SDK则添加）

            services.AddDbContext<NFineCoreDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQLConnection")), ServiceLifetime.Transient);
            return services.UseSharpRepository(Configuration.GetSection("sharpRepository"), "efCore");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, NFineCoreDbContext context, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }            

            app.UseAuthentication();//使用Cookie的中间件
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "SystemManage",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "SystemSecurity",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "WeixinManage",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "ExampleManage",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            IRegisterService register = RegisterService.Start(env, senparcSetting.Value).UseSenparcGlobal();// 启动 CO2NET 全局注册，必须！
            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value);//微信全局注册，必须！
            register.RegisterTraceLog(ConfigTraceLog);//配置TraceLog

            #region Hangfire 定时任务 
            var jobOptions = new BackgroundJobServerOptions
            {
                Queues = new[] { "test", "default", "jobs" },//队列名称，只能为小写
                WorkerCount = Environment.ProcessorCount * 5, //并发任务数
                ServerName = "hangfire1",//服务器名称
            };
            app.UseHangfireServer(jobOptions);
            app.UseHangfireDashboard();
            #endregion
            app.UseStatusCodePagesWithRedirects("/Errors/Http{0}"); // 绝对路径
            app.UseStaticHttpContext();
            AutoMapperConfig.RegisterMappings();
        }

        /// <summary>
        /// 配置微信跟踪日志
        /// </summary>
        private void ConfigTraceLog()
        {
            //这里设为Debug状态时，/App_Data/WeixinTraceLog/目录下会生成日志文件记录所有的API请求日志，正式发布版本建议关闭

            //如果全局的IsDebug（Senparc.CO2NET.Config.IsDebug）为false，此处可以单独设置true，否则自动为true
            Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog("系统日志", "系统启动");//只在Senparc.Weixin.Config.IsDebug = true的情况下生效

            //全局自定义日志记录回调
            Senparc.CO2NET.Trace.SenparcTrace.OnLogFunc = () =>
            {
                //加入每次触发Log后需要执行的代码
            };

            //当发生基于WeixinException的异常时触发
            WeixinTrace.OnWeixinExceptionFunc = ex =>
            {
                //加入每次触发WeixinExceptionLog后需要执行的代码

                //发送模板消息给管理员
                //var eventService = new Senparc.Weixin.MP.Sample.CommonService.EventService();
                //eventService.ConfigOnWeixinExceptionFunc(ex);
            };
        }
    }
}
