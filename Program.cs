using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using log4net;

namespace WebAuslink
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging((context, loggingBuilder) =>
                {
                    loggingBuilder.AddFilter("system", LogLevel.Warning);
                    loggingBuilder.AddFilter("Microsoft",LogLevel.Warning);
                    loggingBuilder.AddLog4Net();
       
                });



            
    }
}
