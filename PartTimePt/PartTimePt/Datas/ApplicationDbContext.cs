using Microsoft.EntityFrameworkCore;
using PartTimePt.Models.DatabaseModel;

namespace PartTimePt.Datas;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<ExampleTable> ExampleTable { get; set; } = null!;
}
