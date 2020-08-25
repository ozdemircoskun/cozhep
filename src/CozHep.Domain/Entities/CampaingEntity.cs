using CozHep.Domain.Core.Entities;
using System;

namespace CozHep.Domain.Entities
{
    public class CampaingEntity : Entity
    {
        public CampaingEntity(Guid id, string name, string productCode, int duration, int pmLimit, int targetSalesCount, DateTime beginTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            ProductCode = productCode;
            Duration = duration;
            PmLimit = pmLimit;
            TargetSalesCount = targetSalesCount;
            BeginTime = beginTime;
            EndTime = endTime;
        }

        // Empty constructor for EF
        protected CampaingEntity() { }
        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public int Duration { get; private set; }
        public int PmLimit { get; private set; }
        public int TargetSalesCount { get; private set; }
        public DateTime BeginTime { get; private set; }
        public DateTime EndTime { get; private set; }
    }
}