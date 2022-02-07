using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bank_service.Entity
{
    public class TransactionHistory
    {
        [Key]
        public string TransactionId { get; set; }
        public string SenderName { get; set; }
        public string RecevierName { get; set; }
        public double Amount { get; set; }
        public string SenderAccountNumber { get; set; }
        public string RecevierAccountNumber { get; set; }
        public string Message { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
    }
}