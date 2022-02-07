﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_service.Exceptions
{
    public class InvalidPasswordException : Exception
    {

        public InvalidPasswordException( )
        {
           
        }

        public InvalidPasswordException(string message) : base(message)
        {
           
        }

        public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
        {
           
        }
    }
}