using System.ComponentModel.DataAnnotations;

namespace Omnichannel.Models
{
    public class CallDriver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CallDriverName { get; set; }
    }
}
