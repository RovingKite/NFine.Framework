using AutoMapper;
using Hangfire;
using Hangfire.RecurringJobExtensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFineCore.EntityFramework;
using NFineCore.Service;
using NFineCore.Service.SystemManage;
using NFineCore.Support;
using NFineCore.Web.Filters;
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
            //services.AddDistributedMemoryCache();//启用session之前必须先添加内存
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
            services.AddTransient(typeof(DutyService));
            services.AddTransient(typeof(LoginLogService));
            services.AddTransient(typeof(OperateLogService));
            services.AddTransient(typeof(OrganizeService));
            services.AddTransient(typeof(PermissionService));
            services.AddTransient(typeof(ResourceService));
            services.AddTransient(typeof(RoleService));
            services.AddTransient(typeof(UserService));
            services.AddScoped<IAttachService, AttachService>();
            #endregion

            services.AddDbContext<NFineCoreDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQLConnection")), ServiceLifetime.Transient);
            return services.UseSharpRepository(Configuration.GetSection("sharpRepository"), "efCore");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, NFineCoreDbContext context)
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

            app.UseStaticHttpContext();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
