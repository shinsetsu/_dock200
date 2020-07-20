using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _dock200.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using _dock200.Data;
using Microsoft.EntityFrameworkCore;

namespace _dock200
{
    public class Program
    {


        public static void Main(string[] args)
        {




            var h = CreateHostBuilder(args).Build();





             //MiddleWare? 
            h.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
    }
}
