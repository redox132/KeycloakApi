using Microsoft.EntityFrameworkCore;
using PeopleForce.Domain;

namespace PeopleForce.Infrastructure.PeopleForceAppDbContext;

public class PeopleAppDbContext : DbContext
{
    public PeopleAppDbContext(DbContextOptions<PeopleAppDbContext> options) : base(options) { }
    
    public DbSet<User>  Users { get; set; }
}