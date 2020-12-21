using System;

namespace Lab5
{
    public class Transaction
    {
        public int id;
        private Account _from;
        private Account _to;
        public double Amount;
        private string _status;

        public Transaction(Account f, Account t, double am)
        {
            id = 0;
            _from = f;
            _to = t;
            Amount = am;
            _status = "done";
            Transfer();
        }

        public void Cancel()
        {
            if (!_to.Withdraw(Amount)) throw new Exception("Not enough money");
            _from.AddMoney(Amount);
            _status = "cancelled";
        }

        private void Transfer()
        {
            if (_from.Withdraw(Amount))
            {
                _to.AddMoney(Amount);
            }
            else
            {
                throw new Exception("Not enough money");
            }
        }
    }
}