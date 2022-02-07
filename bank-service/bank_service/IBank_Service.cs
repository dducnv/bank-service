using bank_service.Dto;
using bank_service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace bank_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBank_Service" in both code and config file together.
    [ServiceContract]
    public interface IBank_Service
    {
        [OperationContract]
        AccountDto GetInfoAccount(string AccountNumber,string PhoneNumber);
        [OperationContract]
        string Register(AccountDto account);
        [OperationContract]
        AccountDto Login(LoginDto loginDto);
        [OperationContract]
        TransferDto Transfers(TransferDto transfer,int otp);
        [OperationContract]
        int SendOtp(string PhoneNumber);
        [OperationContract]
        List<TransactionHistory> transactionHistory(string AccountNumber);    }

}
