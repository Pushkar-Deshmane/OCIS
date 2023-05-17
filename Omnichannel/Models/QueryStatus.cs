using System.ComponentModel.DataAnnotations;

namespace Omnichannel.Models
{
    public class QueryStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QueryStatusName { get; set; }
    }
}
