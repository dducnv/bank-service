using bank_service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace bank_service.Services
{
    public class AccountDataService
    {
        public async Task<Account> Get(int id)
        {
           /* using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.AssetTransactions)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }*/
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            /*  using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
              {
                  IEnumerable<Account> entities = await context.Accounts
                      .Include(a => a.AccountHolder)
                      .Include(a => a.AssetTransactions)
                      .ToListAsync();
                  return entities;
              }*/
            throw new NotImplementedException();
        }

        public async Task<Account> GetByEmail(string email)
        {
            /* using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
             {
                 return await context.Accounts
                     .Include(a => a.AccountHolder)
                     .Include(a => a.AssetTransactions)
                     .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
             }*/
            throw new NotImplementedException();
        }

        public async Task<Account> GetByPhoneNumber(string phoneNumber)
        {
            /*  using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
              {
                  return await context.Accounts
                      .Include(a => a.AccountHolder)
                      .Include(a => a.AssetTransactions)
                      .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
              }*/
            throw new NotImplementedException();
        }

    }
}