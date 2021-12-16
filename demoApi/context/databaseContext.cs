using demoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoApi.context
{
	public class databaseContext:DbContext
	{
		public databaseContext(DbContextOptions<databaseContext> options):base(options)
		{

		}
		public DbSet<Employee> employees { get; set; }
	}
}
