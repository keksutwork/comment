using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Models.ViewModel;
namespace MessageBoard.Models.Interfaces
{
    public interface IAccountService
    {
        Guid? Login(LoginViewModel AccountData);
        bool Regeister(LoginViewModel AccountData);
        bool HavaSameAccountName(string AccountName);
    }
}
