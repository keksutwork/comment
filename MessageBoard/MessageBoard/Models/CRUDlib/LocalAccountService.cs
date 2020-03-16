using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBoard.Models.Interfaces;
using MessageBoard.Models;
using MessageBoard.Models.ViewModel;
namespace MessageBoard.Models.CRUDlib
{
    public class LocalAccountService : IAccountService
    {
        private readonly MessageDbEntities dbEntities;

        public LocalAccountService()
        {
            dbEntities = new MessageDbEntities();
        }
        public bool HavaSameAccountName(string userAccount)
        {
            return dbEntities.UserAccount.Any(data => data.AccountName == userAccount);
        }

        public Guid? Login(LoginViewModel AccountData)
        {
            //使用SHA512加密 密碼
            string hashPassword = Hash.GetHashString(AccountData.AccountPassword);

            //比對資料庫
            UserAccount u = dbEntities.UserAccount.Where(t => t.AccountName == AccountData.AccountName
                                       && t.AccountPassword == hashPassword).FirstOrDefault();
            if (u == null)
            {
                return null;
            }
            else
            {
                return u.UserId;
            }
        }

        public bool Regeister(LoginViewModel accountData)
        {
            //使用SHA512加密 密碼
            string hashPassword = Hash.GetHashString(accountData.AccountPassword);

            //建立帳號資料物件 
            UserAccount user = new UserAccount()
            {
                UserId = Guid.NewGuid(),
                AccountName = accountData.AccountName,
                AccountPassword = hashPassword,
            };

            //加入到資料庫
            dbEntities.UserAccount.Add(user);
            try
            {
                dbEntities.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}