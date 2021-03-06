using GTSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GTSharp.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}