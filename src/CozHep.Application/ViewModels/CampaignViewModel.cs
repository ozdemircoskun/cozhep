using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CozHep.Application.ViewModels
{
    public class CampaignViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public string ProductCode { get; set; }

        public int Duration { get; set; }

        public int PmLimit { get; set; }

        public int TargetSalesCount { get; set; }

    }
}
