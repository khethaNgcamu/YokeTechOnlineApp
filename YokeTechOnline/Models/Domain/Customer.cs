using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace YokeTechOnline.Models.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
       
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;
        [Required, StringLength(13)]
        public string Phone { get; set; } = string.Empty;
        [ValidateNever]
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
