using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _dock200.Models;

namespace _dock200.Data
{
	public class _DBC : DbContext
	{
		public _DBC(DbContextOptions<_DBC> options)
		    : base(options)
		{
		}


		
		public DbSet<_dock200.Models.shinIps2> shinIps2 { get; set; }
		public DbSet<_dock200.Models.shinSiteMetrics> shinSiteMetrics { get; set; }
		public DbSet<_dock200.Models.shinUserSessionSettings> shinUserSessionSettings { get; set; }



		public DbSet<_dock200.Models.RefEmpAp_M> RefEmpAp_M { get; set; }

	}
}
