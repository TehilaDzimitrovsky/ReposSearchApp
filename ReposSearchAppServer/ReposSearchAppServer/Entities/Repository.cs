using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReposSearchAppServer.Entities
{
    public class Repository
    {
        [Key]
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string HtmlUrl { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime SavedDate { get; set; }
    }
}
