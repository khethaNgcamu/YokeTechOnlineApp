using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace YokeTechOnline.Models.Domain
{
    public class Vendor
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string ContactPerson { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [StringLength(13)]
        public string phone { get; set; } = string.Empty;
        [ValidateNever]
        public ICollection<Product> Products { get; set; }

    }
}
