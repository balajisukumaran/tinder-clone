using Microsoft.EntityFrameworkCore;
using Tinder.API.Models;

namespace Tinder.API.Data
{
    
    //S1: Create Context class and inherit DbContext
    public class DataContext : DbContext
    {
        
        //S2:Declare Constructor and Create DbContextOptions parameter and call base class constructor
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
        
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    }
}