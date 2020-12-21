using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Bank
    {
        
        private static int _bankId = 1;
        private int _clientId = 1;
        private int _accountId = 1;
        private int _transactionId = 1;
        public List<Client> Clients = new List<Client>();
        public List<Transaction> Transactions = new List<Transaction>();
        public Dictionary<double, double> depositPercents = new Dictionary<double, double>();
        private int _id;
        private double _percent;
        private double _commision;
        private double _untrustedLimit;

        public Bank(double perc, int com, double unLimit, Dictionary<double, double> percents)
        {
            _id = _bankId;
            _bankId++;
            _percent = perc;
            _commision = com;
            _untrustedLimit = unLimit;
            depositPercents = percents;
        }

        public void AddClient(Client cl)
        {
            cl.Id = _clientId;
            cl.Limit = _untrustedLimit;
            _clientId++;
        }
        public void Transfer(Account from, Account to, double money)
        {
            try
            {
                Transactions.Add(new Transaction(from, to, money));
                Transactions[Transactions.Count - 1].id = _transactionId;
                _transactionId++;
            }
            catch
            {
                throw new Exception("Unable to transfer money");
            }
        }
    }
}