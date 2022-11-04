using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Cosmos.Sql.Function.Test;
using Sample.Sql.Extensions;
using Sample.Sql.Function.Test.DataAccess;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Sample.Cosmos.Sql.Function.Test;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var azureSqlConnectionString = builder.GetContext().Configuration.GetConnectionString("AzureSqlConnectionString");

        builder.Services.AddDbContext<ReportDBContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(azureSqlConnectionString);
            
        });

        builder.Services.AddSqlAuthenticationProvider(azureSqlConnectionString);

        builder.Services.AddScoped<IReportRepository, ReportRepository>();
    }
}
