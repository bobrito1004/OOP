using System;

namespace Lab5
{
    public class DebitAccount : Account
    {
        private double bonus;
        public DebitAccount(Client c, double perc) : base(c)
        {
            initialPerc = perc;
        }

        public override bool Withdraw(double money)
        {
            if (money < 0) throw new Exception("Negative number");
            if (!Owner.IsTrusted && !(Owner.Limit < money)) throw new Exception("TrustLimit");
            if (Balance < money)
            {
                return false;
            }
            Balance -= money;
            return true;
        }

        public override void CountBonus()
        {
            bonus += Balance * (initialPerc / 100);
        }
        public override void AddBonus()
        {
            Balance += bonus;
            bonus = 0;
        }
    }
}