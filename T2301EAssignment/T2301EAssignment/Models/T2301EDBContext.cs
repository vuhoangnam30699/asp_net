using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace T2301EAssignment.Models
{
	public class T2301EDBContext : DbContext
	{
		public T2301EDBContext(DbContextOptions<T2301EDBContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=VuHoangNam;Initial Catalog=HR_Manage;User ID=sa;Password=1234567890;MultipleActiveResultSets=True;Application Name=EntityFramework;Encrypt=False");
		}
		public DbSet<Department> Department_Tbl { get; set; }
		public DbSet<Employee> Employee_Tbl { get; set; }
	}
}
