using System.Collections.Generic;
using ProjectSmsSendler.Model;

namespace SmsSendler.Interface
{
    public interface ISmsSendler
    {
        void SendMessageById(int id, List<Account> accounts,string message);
        void SendMessageAllUsers(List<Account> accounts, string message);
        void SendMessageUsers(List<Account> accounts, string message,int countUsers);
    }
}
