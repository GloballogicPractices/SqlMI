using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.Sql.Function.Test.Model;

namespace Sample.Sql.Function.Test.DataAccess;

public class ReportDBContext : DbContext
{
    public readonly IConfiguration configuration;
    public ReportDBContext(DbContextOptions options)
        : base(options)

    {
        this.Database.EnsureCreated();
    }

    public DbSet<Report> Reports { get; set; }
}
