using ReposSearchAppServer.Entities;

namespace ReposSearchAppServer.Interfaces
{
    public interface ISearchInterface
    {
        public Task<List<Repository>> SearchRepos(string searchTerm);
    }
}
