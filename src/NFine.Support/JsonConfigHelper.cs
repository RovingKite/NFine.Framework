using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NFine.Support
{
    public class JsonConfigHelper
    {
        public static T GetAppSettings<T>(string key) where T : class, new()
        {
            var baseDir = AppContext.BaseDirectory;
            var indexSrc = baseDir.IndexOf("src");
            var subToSrc = baseDir.Substring(0, indexSrc);

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })
                .Build();
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }
    }
}
