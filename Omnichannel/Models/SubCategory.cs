using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omnichannel.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public int CallReasonId { get; set; }
        [ForeignKey("CallReasonId")]
        [ValidateNever]
        public CallReason CallReason { get; set; }
    }
}
