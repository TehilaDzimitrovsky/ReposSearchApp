using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReposSearchAppServer.Entities;
using ReposSearchAppServer.Interfaces;

namespace ReposSearchAppServer.Controllers
{
    [ApiController]
    [Route("Search")]
    public class SearchRepoController : ControllerBase
    {
        private readonly ISearchInterface _searchInterface;
        public SearchRepoController(ISearchInterface searchInterface)
        {
            _searchInterface = searchInterface;
        }

        [Authorize]
        [HttpGet("SearchRepos/{term}")]
        public async Task<IActionResult> SearchRepos(string term)
        {
            try
            {
                List<Repository> repos = await _searchInterface.SearchRepos(term);
                return Ok(repos);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
