using Microsoft.EntityFrameworkCore;
using CommanderGQL.Models;

namespace CommanderGQL.Data;
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options): base(options)
    {

    }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet <Command> Commands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Platform>()
            .HasMany(prop => prop.Commands)
            .WithOne(prop => prop.Platform!)
            .HasForeignKey(prop => prop.PlatformId);

        modelBuilder
            .Entity<Command>()
            .HasOne(prop => prop.Platform)
            .WithMany(prop => prop.Commands)
            .HasForeignKey(prop => prop.PlatformId);
    }
}
