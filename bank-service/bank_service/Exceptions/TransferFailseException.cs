using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class TransferFailseException : Exception
    {
        public TransferFailseException()
        {
        }

        public TransferFailseException(string message)
            : base(message)
        {
        }

        public TransferFailseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}