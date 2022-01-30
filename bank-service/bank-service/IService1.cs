using bank_service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bank_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Login Login(Login login);
        [OperationContract]
        AccountDto Register(AccountDto accountDto);
        [OperationContract]
        AccountDto getInfo(string token, int? id);
        [OperationContract]
        Transfer Transfer(Transfer transfer);
        [OperationContract]
        TransactionHistoryDto TransactionHistory(TransactionHistoryDto transactionHistoryDto);
    }

   
}
