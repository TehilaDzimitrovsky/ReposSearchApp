using ReposSearchAppServer.Entities;

namespace ReposSearchAppServer.Interfaces
{
    public interface IAuthInterface
    {
        public string GenerateJwtToken();
    }
}
