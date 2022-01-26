using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Entity
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string IndetityNumber { get; set; }
        public double Balance { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }
    }
}