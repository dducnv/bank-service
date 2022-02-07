using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class EmailAlreadyExists : Exception
    {
        public string Email { get; set; }
        public EmailAlreadyExists(string email)
        {
            Email = email;
        }

        public EmailAlreadyExists(string message, string email) : base(message)
        {
            Email = email;
        }

        public EmailAlreadyExists(string message, Exception innerException, string email) : base(message, innerException)
        {
            Email = email;
        }
    }
}