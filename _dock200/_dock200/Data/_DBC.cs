using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _dock200.Data
{
	public class _DBC : IdentityDbContext
	{
		public _DBC(DbContextOptions<_DBC> options)
		    : base(options)
		{
		}
	}
}
