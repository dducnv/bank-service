using bank_service.Data;
using bank_service.Dto;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace bank_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private MyDBContext myDBContext = new MyDBContext();
    

        public AccountDto getInfo(string token,int? id)
        {

            /*            AccountDto accountDto = myDBContext.Accounts.Where(token);
            */
            throw new NotImplementedException();
        }

        public Login Login(Login login)
        {
            return login;

        }

        public AccountDto Register(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public TransactionHistoryDto TransactionHistory(TransactionHistoryDto transactionHistoryDto)
        {
            throw new NotImplementedException();
        }

        public Transfer Transfer(Transfer transfer)
        {
            throw new NotImplementedException();
        }

      
    }
}
