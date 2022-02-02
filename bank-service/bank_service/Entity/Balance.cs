using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Entity
{
    public class Balance
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public double Value { get; set; }
        public virtual Account Accounts { get; set; }
    }
}