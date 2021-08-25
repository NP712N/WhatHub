using Portal.Domain.Core;
using Portal.Infrastructure.EF;

namespace Portal.Infrastructure.Repositories.SystemLogs
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}