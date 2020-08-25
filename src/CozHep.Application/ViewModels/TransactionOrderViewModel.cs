using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CozHep.Application.ViewModels
{
    public class TransactionOrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The ProductCode is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("ProductCode")]
        public string ProductCode { get; set; }

        public int Quantity { get; set; }

  

    }
}
