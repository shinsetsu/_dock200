using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _dock200.Models;
using System.Linq;

namespace _dock200.Data
{
    //https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli

    //dotnet ef dbcontext scaffold ... --context-dir Data --output-dir Models    
    //dotnet ef dbcontext scaffold ... --namespace Your.Namespace --context-namespace Your.DbContext.Namespace

    //https://docs.microsoft.com/en-us/ef/core/managing-schemas/ensure-created
    //context.Database.EnsureDeleted();
    // context.Database.EnsureCreated();

    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1
    public class _DBC : DbContext
    {
        public _DBC()
        {
        }

        public _DBC(DbContextOptions<_DBC> options) : base(options) { }





        public DbSet<_dock200.Models.shinIps2> shinIps2 { get; set; }
        public DbSet<_dock200.Models.shinSiteMetrics> shinSiteMetrics { get; set; }




        public DbSet<_dock200.Models.RefEmpAp_M> RefEmpAp_M { get; set; }



    }


    public static class _DBInitalize
    {

        public static void Init(_DBC _dbc)
        {
            _dbc.Database.EnsureCreated();


            if (!_dbc.shinIps2.Any()) { _dbc.Add(new shinIps2 { IP = "Init" }); }   // Looking if DB has been seeded
            if (!_dbc.shinSiteMetrics.Any()) { _dbc.Add(new shinSiteMetrics { pageViewsDebug = 1, pageViewsRelease = 1, pageViewsEx = 1 }); }   // Looking if DB has been seeded


            _dbc.SaveChanges();
        }
    }
}