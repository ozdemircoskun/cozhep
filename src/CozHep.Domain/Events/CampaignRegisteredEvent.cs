using CozHep.Domain.Core.Events;
using System;

namespace CozHep.Domain.Events
{
    public class CampaignRegisteredEvent : Event
    {
        public CampaignRegisteredEvent(Guid id, string name, string productCode, int duration, int pmLimit, int targetSalesCount)
        {
            Id = id;
            ProductCode = productCode;
            Duration = duration;
            PmLimit = pmLimit;
            TargetSalesCount = targetSalesCount;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public int Duration { get; private set; }
        public int PmLimit { get; private set; }
        public int TargetSalesCount { get; private set; }

    }
}