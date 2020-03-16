using MessageBoard.Models.ViewModel;

namespace MessageBoard.Models.AccountDataModel
{
    public interface IAccountRegisterService
    {
        bool Regeister(LoginViewModel AccountData);
        bool HavaSameAccountName(string AccountName);
    }
}