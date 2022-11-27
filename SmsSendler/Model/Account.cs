using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSmsSendler.Model
{
    public class Account
    {
        public User attachedUser { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int accountBalance { get; set; }

        public void BuildAccount(User user,string nickname,string password,string email, int accountBalance)
        {
            attachedUser = user;
            this.nickname = nickname;
            this.password = password;
            this.email = email;
            this.accountBalance = accountBalance;
        }
    }
}
