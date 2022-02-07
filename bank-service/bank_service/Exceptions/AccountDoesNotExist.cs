using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class AccountDoesNotExist : Exception
    {
        public AccountDoesNotExist()
        {
        }

        public AccountDoesNotExist(string message)
            : base(message)
        {
        }

        public AccountDoesNotExist(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}