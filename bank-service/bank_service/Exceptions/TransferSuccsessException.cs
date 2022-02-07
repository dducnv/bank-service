using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class TransferSuccsessException : Exception
    {
        public TransferSuccsessException()
        {
        }

        public TransferSuccsessException(string message)
            : base(message)
        {
        }

        public TransferSuccsessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}