using bank_service.Data;
using bank_service.Dto;
using bank_service.Entity;
using bank_service.Exceptions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace bank_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bank_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Bank_Service.svc or Bank_Service.svc.cs at the Solution Explorer and start debugging.
    public class Bank_Service : IBank_Service
    {
        private readonly IPasswordHasher _passwordHasher;
        MyDBContext myDBContext = new MyDBContext();
        private Random _random = new Random();
        private int _otp = 0;

        public AccountDto GetInfoAccount(string AccountNumber, string PhoneNumber)
        {
            var GetInfo = myDBContext.Accounts.FirstOrDefault(e => e.AccountNumber == AccountNumber && e.PhoneNumber == PhoneNumber);
            if(GetInfo == null)
            {
                throw new AccountDoesNotExist("Account Does Not Exist");
            }
            AccountDto accountDto = new AccountDto()
            {
                AccountNumber = GetInfo.AccountNumber,
                FistName = GetInfo.FistName,
                LastName = GetInfo.LastName,
                Email = GetInfo.Email,
                Balance = GetInfo.Balance,
                Address = GetInfo.Address,
                Status = GetInfo.Status
            };
     
            return accountDto;
        }
        public string Register(AccountDto account)
        {
            var findByEmail = myDBContext.Accounts.FirstOrDefault(e => e.Email == account.Email);
            var findByPhone = myDBContext.Accounts.FirstOrDefault(e => e.PhoneNumber == account.PhoneNumber);
            if(findByEmail != null)
            {
                return "Email Đã Tồn Tại";
            }
            if (findByPhone != null)
            {
                return "SĐT Đã Tồn Tại";
            }
            if (account.Password == account.PasswordConfirm)
            {
                IPasswordHasher hasher  = new PasswordHasher();
                string hashedPassword = hasher.HashPassword(account.Password); 
                Account accountSave = new Account()
                {
                    AccountNumber = _random.Next(1000, 9000).ToString() + _random.Next(1000, 9000).ToString() + _random.Next(1000, 9000).ToString() + _random.Next(1000, 9000).ToString(),
                    FistName = account.FistName,
                    LastName =account.LastName,
                    Email = account.Email,
                    PhoneNumber = account.PhoneNumber,
                    Password = hashedPassword,
                    IndetityNumber = account.IndetityNumber,
                    Address = account.Address,
                    Balance = 4000,
                    Birthday = account.Birthday,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Status = 0,
                };
                myDBContext.Accounts.Add(accountSave);
       
                myDBContext.SaveChanges();
                return "success";
            }
           
            return "false";
        }

        public AccountDto Login(LoginDto loginDto)
        {
            IPasswordHasher hasher = new PasswordHasher();
            var storedAccount = myDBContext.Accounts.FirstOrDefault(m => m.PhoneNumber == loginDto.PhoneNumber);
            if(storedAccount == null)
            {
                throw new PhoneNotFoundException(loginDto.PhoneNumber,"Số Điện Thoại Không Tìm Thấy");
            }
            PasswordVerificationResult passwordResult = hasher.VerifyHashedPassword(storedAccount.Password, loginDto.Password);
            if(passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException("InvalidPasswordException");
            }
            var accountResult = new AccountDto()
            {
                AccountNumber = storedAccount.AccountNumber,
                FistName = storedAccount.FistName,
                LastName = storedAccount.LastName,
                Email = storedAccount.Email,
                PhoneNumber = storedAccount.PhoneNumber,
                Birthday = storedAccount.Birthday,
                Address = storedAccount.Address,
                Balance = storedAccount.Balance
            };
            return accountResult;
        }

        public TransferDto Transfers(TransferDto transfer,int otp)
        {
            IPasswordHasher hasher = new PasswordHasher();
            using (DbContextTransaction transaction = myDBContext.Database.BeginTransaction())
                {
                   
                    try
                    {
                       double amount = double.Parse(transfer.Amount);
                       var sender = myDBContext.Accounts.FirstOrDefault(m => m.AccountNumber == transfer.AccountNumberSender);
                       var receiver = myDBContext.Accounts.FirstOrDefault(m => m.AccountNumber == transfer.AccountNumberReceiver);
                        PasswordVerificationResult passwordResult = hasher.VerifyHashedPassword(sender.Password, transfer.Password);
                    if (passwordResult != PasswordVerificationResult.Success)
                    {
                      throw new InvalidPasswordException("InvalidPasswordException");
                    }
                    else if(otp != _otp)
                    {
                        throw new InvalidOtpException("InvalidOtpException");
                    }
                    else
                    {
                        sender.Balance = sender.Balance - amount;
                        receiver.Balance = receiver.Balance + amount;
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[8];
                       

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[_random.Next(chars.Length)];
                        }
                        var TransactionId = new String(stringChars);
                        TransactionHistory transactionHistory = new TransactionHistory()
                        {
                            TransactionId = TransactionId,
                            SenderName = sender.LastName + " " + sender.FistName,
                            RecevierName = receiver.LastName + " " + receiver.FistName,
                            Amount = amount,
                            SenderAccountNumber = sender.AccountNumber,
                            RecevierAccountNumber = receiver.AccountNumber,
                            TransactionType = "Transfer",
                            Message = transfer.Message,
                            CreatedAt = DateTime.Now,
                            Status = 1

                        };
                        myDBContext.TransactionHistories.Add(transactionHistory);
                        myDBContext.SaveChanges();
                        transaction.Commit();
                    }        
                }
                    catch (DbEntityValidationException e)
                    {
                       transaction.Rollback();
                       throw new TransferFailseException("TransferFalse");
                }
                }

            return transfer;
        }

        public List<TransactionHistory> transactionHistory(string AccountNumber)
        {
           return myDBContext.TransactionHistories.Where(
               m => m.RecevierAccountNumber == AccountNumber 
                 || m.SenderAccountNumber == AccountNumber).ToList();
        }

        public int SendOtp(string PhoneNumber)
        {
            var accountSid = ConfigurationManager.AppSettings["SMSAccountIdentification"];
            var authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];
            var fromNumber = ConfigurationManager.AppSettings["SMSAccountFrom"];
            var otp = _random.Next(100000, 999999);
            TwilioClient.Init(accountSid, authToken);
            MessageResource.Create(
                body: "Your OTP Code " + otp + ".",
                from: new Twilio.Types.PhoneNumber(fromNumber),
                to: new Twilio.Types.PhoneNumber(PhoneNumber)
            );
            _otp = otp;
            
            return otp;
        }
    }
}
