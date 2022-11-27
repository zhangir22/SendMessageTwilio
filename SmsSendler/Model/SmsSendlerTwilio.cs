using SmsSendler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ProjectSmsSendler.Model
{
    public class SmsSendlerTwilio : ISmsSendler
    {
        private TwilioClient twilio { get; set; }
        private void AuthToHost()
        {
            string accountSid = "AC7c3e718e51a205383cb01327f326df89";
            string accountToken = "35453dc142a9b6e4649b59d96ca5cf04";
            TwilioClient.Init(accountSid, accountToken);

        }
        private Account GetAccountById(int id,List<Account> accounts)
        {
            return accounts.Where(u => u.attachedUser.id == id).FirstOrDefault();
        }
       
        public  void SendMessageById(int id, List<Account> accounts, string message)
        {
            AuthToHost();
            var messageOptions = new CreateMessageOptions(
            new PhoneNumber(GetAccountById(id,accounts).attachedUser.phoneNumber));
            messageOptions.MessagingServiceSid = "MG36db6df01821a520ac384c78144fbf12";
            messageOptions.Body = message + $" Ваш баланс {GetAccountById(id, accounts).accountBalance}";
            var m = MessageResource.Create(messageOptions);
            Console.WriteLine(m.Body);
        }

        public void SendMessageAllUsers(List<Account> accounts, string message)
        {
            foreach(var item in accounts)
            {
                var messageOptions = new CreateMessageOptions(
                 new PhoneNumber(item.attachedUser.phoneNumber));
                messageOptions.MessagingServiceSid = "MG36db6df01821a520ac384c78144fbf12";
                messageOptions.Body = message + $" Ваш баланс {item.accountBalance}";
            }
            
        }

        public void SendMessageUsers(List<Account> accounts, string message,int countUsers)
        {
            if (countUsers > accounts.Count)
                countUsers = accounts.Count;

            for(int i = 0; i < countUsers; i++)
            {
                var messageOptions = new CreateMessageOptions(
                new PhoneNumber(accounts[i].attachedUser.phoneNumber));
                messageOptions.MessagingServiceSid = "MG36db6df01821a520ac384c78144fbf12";
                messageOptions.Body = message + $" Ваш баланс {accounts[i].accountBalance}";
            }
        }
      

    }

    
}
