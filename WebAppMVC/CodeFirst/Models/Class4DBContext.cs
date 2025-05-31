using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirst.Models
{
    public class Class4DBContext : DbContext
    {
        public Class4DBContext(DbContextOptions<Class4DBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VuHoangNam;Initial Catalog=T2301E_SEM3;User ID=sa;Password=1234567890;MultipleActiveResultSets=True;Application Name=EntityFramework;Encrypt=False");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
