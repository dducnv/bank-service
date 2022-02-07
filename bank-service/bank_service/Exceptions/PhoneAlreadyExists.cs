using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class PhoneAlreadyExists : Exception
    {
        public string Phone { get; set; }
        public PhoneAlreadyExists(string phone)
        {
            Phone = phone;
        }

        public PhoneAlreadyExists(string message, string phone) : base(message)
        {
            Phone = phone;
        }

        public PhoneAlreadyExists(string message, Exception innerException, string phone) : base(message, innerException)
        {
            Phone = phone;
        }
    }
}