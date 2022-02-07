using bank_client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank_client.Models
{
    public class MultiModel
    {
        public AccountDto accountDto { get; set; }
        public TransferDto TransferDto { get; set; }
    }
}