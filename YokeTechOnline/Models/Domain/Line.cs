using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace YokeTechOnline.Models.Domain
{
    public class Line
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Units { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public int InvoiceId { get; set; }
        [ValidateNever]
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
    }
}
