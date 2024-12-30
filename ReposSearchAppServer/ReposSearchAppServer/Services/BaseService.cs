
namespace ReposSearchAppServer.Services
{
    public class BaseService
    {
        private readonly ILogger<BaseService> _logger;
        public AppContext _dbContext;
        public BaseService(
   AppContext dbContext,
   ILogger<BaseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
