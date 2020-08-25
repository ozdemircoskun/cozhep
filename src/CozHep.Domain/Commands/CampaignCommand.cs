using CozHep.Domain.Core.Commands;
using System;

namespace CozHep.Domain.Commands
{
    public abstract class CampaignCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string ProductCode { get; protected set; }
        public int Duration { get; protected set; }
        public int PmLimit { get; protected set; }
        public int TargetSalesCount { get; protected set; }

    }
}