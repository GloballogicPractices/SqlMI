using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.Sql.Function.Test.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Sql.Function.Test.DataAccess;

public class ReportRepository : IReportRepository
{
    private readonly ReportDBContext reportDBContext;
    public ReportRepository(ReportDBContext context, IConfiguration configuration)
    {
        reportDBContext = context;
    }

    public Task AddAsync(Report report)
    {
        reportDBContext.Add(report);
        return reportDBContext.SaveChangesAsync();
    }

    public Task<List<Report>> GetAllRecordAsync()
    {
        return reportDBContext.Reports.ToListAsync();
    }

    public Task<Report> GetByAsync(int id)
    {
        return reportDBContext.Reports.FirstOrDefaultAsync(x => x.ReportId == id);
    }

    public Task Update(Report report)
    {
        reportDBContext.Update(report);
        return reportDBContext.SaveChangesAsync();
    }
}
