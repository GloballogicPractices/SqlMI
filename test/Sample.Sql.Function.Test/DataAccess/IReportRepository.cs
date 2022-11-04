using Sample.Sql.Function.Test.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Sql.Function.Test.DataAccess;

public interface IReportRepository
{
    Task<Report> GetByAsync(int id);

    Task<List<Report>> GetAllRecordAsync();

    Task AddAsync(Report report);

    Task Update(Report report);
}
