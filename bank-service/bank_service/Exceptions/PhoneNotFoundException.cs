using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class PhoneNotFoundException : Exception
    {
        public string Phone { get; set; }
        public PhoneNotFoundException(string phone)
        {
            Phone = phone;
        }

        public PhoneNotFoundException(string message, string phone) : base(message)
        {
            Phone = phone;
        }

        public PhoneNotFoundException(string message, Exception innerException, string phone) : base(message, innerException)
        {
            Phone = phone;
        }
    }
}