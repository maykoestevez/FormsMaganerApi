using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormApi.Data
{
    public class DynamicFormDbContext : DbContext
    {
        public DynamicFormDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DynamicFormControl> DynamicFormControl { get; set; }
        public DbSet<FormControlOption> FormOptions { get; set; }
        public DbSet<DynamicForm> DynamicForm { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}