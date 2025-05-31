using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShoppingCart.Models
{
    public class Class5DBContext : DbContext
    {
        public Class5DBContext()
        {

        }

        public Class5DBContext(DbContextOptions<Class5DBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VuHoangNam;Initial Catalog=T2301E_SEM3;User ID=sa;Password=1234567890;MultipleActiveResultSets=True;Application Name=EntityFramework;Encrypt=False");
        }
        public DbSet<Mobiles> Mobiles { get; set; }

        public virtual DbSet<MobileDetails> MobileDetails { get; set; }
    }
}
