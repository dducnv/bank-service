using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Entity
{
    public class TransactionHistory
    {
        public string TransactionId { get; set; }
        public string SenderName { get; set; }
        public double Amount { get; set; }
        public string SenderAccountNumber { get; set; }
        public string RecevierAccountNumber { get; set; }
        public string Message { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
    }
}