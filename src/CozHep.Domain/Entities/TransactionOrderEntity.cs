using CozHep.Domain.Core.Entities;
using System;
using System.Security.Cryptography;

namespace CozHep.Domain.Entities
{
    public class TransactionOrderEntity : Entity
    {
        public TransactionOrderEntity(Guid id, string campaignName, string productCode, int pmLimit, int quantity, decimal unitPrice, decimal totalPrice, decimal pmUnitPrice, decimal pmUnitTotalPrice, DateTime parameterTime, DateTime transactionTime)
        {
            Id = id;
            CampaignName = campaignName;
            ProductCode = productCode;
            PmLimit = pmLimit;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            PmUnitPrice = pmUnitPrice;
            PmTotalPrice = pmUnitTotalPrice;
            ParameterTime = parameterTime;
            TransactionTime = transactionTime;
        }

        // Empty constructor for EF
        protected TransactionOrderEntity() { }
        public string CampaignName { get; private set; }
        public string ProductCode { get; private set; }
        public int PmLimit { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal PmUnitPrice { get; private set; }
        public decimal PmTotalPrice { get; private set; }
        public DateTime ParameterTime { get; private set; }
        public DateTime TransactionTime { get; private set; }

    }
}