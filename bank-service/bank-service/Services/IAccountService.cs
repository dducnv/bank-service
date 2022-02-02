using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bank_service.Dto;
namespace bank_service.Services
{
   public interface IAccountService : IDataService<AccountDto>
    {
        Task<AccountDto> GetByPhoneNumber(string phoneNumber);
        Task<AccountDto> GetByEmail(string email);
    }
}
