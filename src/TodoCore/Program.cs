using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TodoCore
{
    public class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(o => o.ThreadCount = 1)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseDefaultHostingConfiguration(args)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
