using Microsoft.EntityFrameworkCore;
using ReposSearchAppServer.Entities;

namespace ReposSearchAppServer
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options) { }
        public DbSet<Repository> Repositories { get; set; }
    }
}
