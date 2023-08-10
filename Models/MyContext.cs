
#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace _5_Chefs_N_Dishes.Models;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Chef> Chefs { get; set; } 
    public DbSet<Dish> Dishes { get; set; } 
}