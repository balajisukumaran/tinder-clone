
using Microsoft.EntityFrameworkCore;
using Tinder.API.Models;

namespace Tinder.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}