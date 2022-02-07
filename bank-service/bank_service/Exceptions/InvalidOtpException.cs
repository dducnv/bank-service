using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class InvalidOtpException : Exception
    {
        public InvalidOtpException()
        {

        }

        public InvalidOtpException(string message) : base(message)
        {

        }

        public InvalidOtpException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}