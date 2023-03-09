using Microsoft.EntityFrameworkCore;
using CommanderGQL.Models;

namespace CommanderGQL.Data;
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options): base(options)
    {

    }
    public DbSet<Platform> Platforms { get; set; }

}
