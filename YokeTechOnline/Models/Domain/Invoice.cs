using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;

namespace YokeTechOnline.Models.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        
        [Required]
        public int CustomerId { get; set; }
        [ValidateNever]
        public virtual Customer Customer { get; set; }
        [ValidateNever]
        public ICollection<Line>? Lines { get; set; }
    }
}
