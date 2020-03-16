using MessageBoard.Models.ViewModel;
using System;

namespace MessageBoard.Models.AccountDataModel
{
    public interface IAccountLoginService
    {
        Guid? Login(LoginViewModel AccountData);
    }
}