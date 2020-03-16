using MessageBoard.Models.MethodLibaray;
using MessageBoard.Models.ViewModel;
using System;
using System.Linq;
namespace MessageBoard.Models.AccountDataModel
{
    internal class LocalAccountRegisterService : IAccountRegisterService
    {
        MessageDbEntities dbEntities = new MessageDbEntities();

        bool IAccountRegisterService.HavaSameAccountName(string AccountName)
        {
            return dbEntities.UserAccount.Any(data => data.AccountName == AccountName);
        }

        bool IAccountRegisterService.Regeister(LoginViewModel AccountData)
        {
            //使用SHA512加密 密碼
            string hashPassword = Hash.GetHashString(AccountData.AccountPassword);

            //建立帳號資料物件 
            UserAccount user = new UserAccount()
            {
                UserId = Guid.NewGuid(),
                AccountName = AccountData.AccountName,
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