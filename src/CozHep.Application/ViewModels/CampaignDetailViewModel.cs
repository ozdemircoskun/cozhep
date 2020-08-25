using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CozHep.Application.ViewModels
{
    public class CampaignDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }
         
        public string Name { get; set; }

        public string ProductCode { get; set; }
         
        public int PmLimit { get; set; }

        public int TotalSalesCount { get; set; }

        public int TargetSalesCount { get; set; }
         
        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

     

    }
}
