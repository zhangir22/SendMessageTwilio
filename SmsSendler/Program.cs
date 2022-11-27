using ProjectSmsSendler.Model;
using SmsSendler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSmsSendler
{
    public class Program
    {
        public static List<User> CreateUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User
            {
                id = 1,
                name = "Zhangir",
                surename = "Galkin",
                phoneNumber = "+77768236918",
                dateBirth = DateTime.Now.ToString("dd-mm-yyyy")
            });
            users.Add(new User
            {
                id = 2,
                name = "Talgat",
                surename = "Alikparov",
                phoneNumber = "+79133772325",
                dateBirth = DateTime.Now.ToString("dd-mm-yyyy")
            });
            users.Add(new User
            {
                id = 3,
                name = "Kal",
                surename = "Mals",
                phoneNumber = "+420777135605",
                dateBirth = DateTime.Now.ToString("dd-mm-yyyy")
            });
            return users;
        }
        public static List<Account> GetExamplesAccounts()
        {
            List<Account> accounts = new List<Account>();
            var users = CreateUsers();
            Account account = new Account();
            accounts.Add(new Account
            {
                attachedUser = users[0],
                nickname = "leen",
                password = "jangir",
                email = "zhangir003@mail.ru",
                accountBalance = 100
            }) ;

            accounts.Add(new Account
            {
                attachedUser = users[1],
                nickname = "admin",
                password = "123",
                email = "admin@maiil.ru",
                accountBalance = 1000
            });

            accounts.Add(new Account
            {
                attachedUser = users[2],
                nickname = "subadmin",
                password = "321",
                email = "subadmin@mail.ru",
                accountBalance = 1
            });
            return accounts;
        }
        static void Main(string[] args)
        {
            ISmsSendler smsSendler = new Model.SmsSendlerTwilio();
         
            var accounts = GetExamplesAccounts();

            smsSendler.SendMessageById(1, accounts, $"Здраствуйте это Жангир");

            Console.ReadLine();
        }
    }
}
