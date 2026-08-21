using Microsoft.EntityFrameworkCore;
using PeopleForce.Domain;

namespace PeopleForce.Infrastructure.PeopleForceAppDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User>  Users { get; set; }
}