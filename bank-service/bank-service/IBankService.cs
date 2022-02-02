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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankService" in both code and config file together.
    [ServiceContract]
    public interface IBankService
    {
       /* [OperationContract]
        Task<Login> Login(Login login);*/
        [OperationContract]
        Task<AccountDto> Register(AccountDto accountDto);
        [OperationContract]
        AccountDto getInfo(string token, int? id);
        [OperationContract]
        Transfer Transfer(Transfer transfer);
        [OperationContract]
        TransactionHistoryDto TransactionHistory(TransactionHistoryDto transactionHistoryDto);
    }
}
