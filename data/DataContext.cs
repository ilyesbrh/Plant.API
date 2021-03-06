using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Plant.API.models;

namespace Plant.API.data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Info> Infos { get; set; }
        
    }
}