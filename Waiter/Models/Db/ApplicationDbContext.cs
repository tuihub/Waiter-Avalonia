using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models.Db
{
    public class ApplicationDbContext : DbContext
    {
        private GlobalContext _globalContext;
        public ApplicationDbContext(GlobalContext globalContext)
        {
            _globalContext = globalContext;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<AppPackageSetting> AppPackageSettings { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbFilePath = _globalContext.SystemConfig.GetRealSqliteDbPath();
            optionsBuilder.UseSqlite($"Data Source={dbFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Conventions.Remove(typeof(ForeignKeyIndexConvention));
        }
    }
}
