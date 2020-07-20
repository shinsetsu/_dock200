using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _dock200.Data;
using _dock200.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _dock200
{
    public class Program
    {
        public static void Main(string[] args, _DBC _dbc)
        {



            var h = CreateHostBuilder(args).Build();


            try { _DBInitalize.Init(_dbc); } catch (Exception e) { throw; }



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
