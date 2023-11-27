using Microsoft.EntityFrameworkCore;

namespace ParacaApi.Models;

public class ParacaContext : DbContext
{
    public ParacaContext(DbContextOptions<ParacaContext> options)
        : base(options)
    {
    }

    public DbSet<Paracaidista> PAracaidistas { get; set; } = null!;
}