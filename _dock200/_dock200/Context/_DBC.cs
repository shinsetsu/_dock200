using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _dock200.Models;
using System.Linq;

namespace _dock200.Data
{

    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1
    public class _DBC : DbContext
    {
        public _DBC(DbContextOptions<_DBC> options) : base(options) { }





        public DbSet<_dock200.Models.shinIps2> shinIps2 { get; set; }
        public DbSet<_dock200.Models.shinSiteMetrics> shinSiteMetrics { get; set; }
        public DbSet<_dock200.Models.shinUserSessionSettings> shinUserSessionSettings { get; set; }



        public DbSet<_dock200.Models.RefEmpAp_M> RefEmpAp_M { get; set; }



    }


    public static class _DBInitalize
    {
        public static void Init(_DBC _dbc)
        {
            _dbc.Database.EnsureCreated();


            if (_dbc.shinIps2.Any()) { return; }   // Looking if DB has been seeded

            var VM = new _shinIps2VM() { };
            VM.Ips.Add(new shinIps2 { IP = "Init" });


            foreach (var _ in VM.Ips) { _dbc.Add(_); }
            _dbc.SaveChanges();
        }
    }
}