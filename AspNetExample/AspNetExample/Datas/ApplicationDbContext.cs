using AspNetExample.Models.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace AspNetExample.Datas;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<TestTable> TestTable { get; set; } = null!;
}
