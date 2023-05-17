using System.ComponentModel.DataAnnotations;

namespace Omnichannel.Models
{
    public class CallReason
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CallReasonName { get; set; }
    }
}
