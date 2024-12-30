using ReposSearchAppServer.Entities;

namespace ReposSearchAppServer.Interfaces
{
    public interface IMarkInterface
    {
        public List<Repository> GetAllMarkedRepos();
        public Task MarkRepo(Repository repo);
        public Task UnMarkRepo(decimal repoId);
    }
}
