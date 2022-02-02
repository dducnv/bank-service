using bank_service.Data;
using bank_service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace bank_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BankService.svc or BankService.svc.cs at the Solution Explorer and start debugging.
    public class BankService : IBankService
    {
        private MyDBContext myDBContext = new MyDBContext();


        public AccountDto getInfo(string token, int? id)
        {

            /*            AccountDto accountDto = myDBContext.Accounts.Where(token);
            */
            throw new NotImplementedException();
        }

     

        public async Task<AccountDto> Register(AccountDto accountDto)
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
