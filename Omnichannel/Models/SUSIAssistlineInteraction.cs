using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Omnichannel.Models
{
    public class SUSIAssistlineInteraction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Call ID")]
        public uint CallId { get; set; }

        [DisplayName("Call Reason")]
        public int CallReasonId { get; set; }
        [ForeignKey("CallReasonId")]
        [ValidateNever]
        public CallReason CallReason { get; set; }

        [DisplayName("Sub Category")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        [ValidateNever]
        public SubCategory SubCategory { get; set; }

        [DisplayName("Further Details")]
        public int FurtherDetailId { get; set; }
        [ForeignKey("FurtherDetailId")]
        [ValidateNever]
        public FurtherDetail FurtherDetail { get; set; }

        [DisplayName("Call Driver")]
        public int CallDriverId { get; set; }
        [ForeignKey("CallDriverId")]
        [ValidateNever]
        public CallDriver CallDriver { get; set; }

        [DisplayName("Information Available to Agent")]
        public string InfoToAgent { get; set; }

        [DisplayName("Query Status")]
        public int QueryStatusId { get; set; }
        [ForeignKey("QueryStatusId")]
        [ValidateNever]
        public QueryStatus QueryStatus { get; set; }
        
        public string Comment { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
