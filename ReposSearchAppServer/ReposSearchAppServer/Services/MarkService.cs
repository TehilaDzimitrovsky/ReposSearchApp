using ReposSearchAppServer.Interfaces;
using ReposSearchAppServer.Entities;

namespace ReposSearchAppServer.Services
{
    public class MarkService : BaseService, IMarkInterface
    {
        public MarkService(
         AppContext ctx,
         ILogger<SearchService> logger) : base(ctx, logger)
        {
        }
        public async Task MarkRepo(Repository repo)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Add(new Repository
                {
                    Id = repo.Id,
                    Name = repo.Name,
                    AvatarUrl = repo.AvatarUrl,
                    HtmlUrl = repo.HtmlUrl,
                    SavedDate = DateTime.UtcNow,
                });
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public async Task UnMarkRepo(decimal repoId)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //nice advance option to unMark a repo
                Repository repo = _dbContext.Repositories.FirstOrDefault(t => t.Id == repoId);
                if (null != repo)
                {
                    _dbContext.Remove(repo);
                }
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public List<Repository> GetAllMarkedRepos()
        {
            return _dbContext.Repositories.OrderBy(u => u.Name).ToList();
        }
    }
}
