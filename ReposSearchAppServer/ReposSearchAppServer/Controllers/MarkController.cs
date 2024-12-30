using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReposSearchAppServer.Entities;
using ReposSearchAppServer.Interfaces;

namespace ReposSearchAppServer.Controllers
{

    [ApiController]
    [Route("Mark")]
    public class MarkController : ControllerBase
    {
        private readonly IMarkInterface _markInterface;
        public MarkController(IMarkInterface markInterface)
        {
            _markInterface = markInterface;
        }

        [Authorize]
        [HttpGet("GetAllMarkedRepos")]
        public IActionResult GetAllMarkedRepos()
        {
            try
            {
                List<Repository> repos = _markInterface.GetAllMarkedRepos();
                return Ok(repos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("MarkRepo")]
        public IActionResult MarkRepo([FromBody] Repository repo)
        {
            try
            {
                _markInterface.MarkRepo(repo);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("UnMarkRepo/{repoId}")]
        public IActionResult UnMarkRepo(decimal repoId)
        {
            try
            {
                _markInterface.UnMarkRepo(repoId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
