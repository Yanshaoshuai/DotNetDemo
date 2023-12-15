using DotNetDemo.WebApi.Utility;
using Microsoft.EntityFrameworkCore;

namespace DotNetDemo.WebApi.DAO
{
    public class MysqlEfContext : DbContext
    {

        public MysqlEfContext(DbContextOptions<MysqlEfContext> options) : base(options)
        {

        }
        public DbSet<Person> person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
