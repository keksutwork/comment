using MessageBoard.Models.ViewModel;
using System;
using System.Linq;
using MessageBoard.Models.MethodLibaray;

namespace MessageBoard.Models.AccountDataModel
{
    public class LocalAccountLoginService : IAccountLoginService
    {
        Guid? IAccountLoginService.Login(LoginViewModel AccountData)
        {
            MessageDbEntities dbEntities = new MessageDbEntities();
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
    }
}