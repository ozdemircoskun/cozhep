using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CozHep.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The ProductCode is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("ProductCode")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Stock is Required")]
        public int Stock { get; set; }


    }
}
