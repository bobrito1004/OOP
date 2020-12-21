using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Lab5
{
    public class Client
    {
        public int Id;
        public string FirstName;
        public string SecondName;
        public string Address;
        public string Passport;
        public bool IsTrusted { set;get; }
        public double Limit;
        public List<Account> Accounts = new List<Account>();
        public Client()
        {
            Id = 0;
            IsTrusted = false;
        }
        
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void Trusted()
        {
            if (Passport != null && Address != null)
            {
                IsTrusted = true;
            }
            else
            {
                IsTrusted = false;
            }
        }
    }
}