using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Omnichannel.Models
{
    public class FurtherDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FurtherDetailName { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        [ValidateNever]
        public SubCategory SubCategory { get; set; }
    }
}
