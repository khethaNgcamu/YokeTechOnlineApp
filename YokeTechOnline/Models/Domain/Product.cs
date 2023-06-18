using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace YokeTechOnline.Models.Domain
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        
        public decimal Discount { get; set; } = 0;
        [Required]
        public DateTime InDate { get; set; } = DateTime.Now;
        [Required]
        public int QOH { get; set; }
        public int VendorId { get; set; }
        [ValidateNever]
        public Vendor Vendor { get; set; }
        [ValidateNever]
        public ICollection<Line>? Lines { get; set; }

    }
}
