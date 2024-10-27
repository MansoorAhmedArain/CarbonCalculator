using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WTechAuth.Areas.Identity.Data;
using WTechAuth.Models;

namespace WTechAuth.Data;
public class WTechAuthDbContext : IdentityDbContext<ApplicationUser>
{
    public WTechAuthDbContext(DbContextOptions<WTechAuthDbContext> options)
        : base(options)
    {
    }
    public DbSet<SummativeResult> SummativeResults { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
