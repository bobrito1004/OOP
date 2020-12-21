using System;

namespace Lab5
{
    public class CreditAccount : Account
    {
        private double limit;
        private double commision;
        public CreditAccount(Client c, double lim, double com) : base(c)
        {
            limit = lim;
        }

        public override bool Withdraw(double money)
        {
            if (money < 0) throw new Exception("Negative");
            if (!Owner.IsTrusted && !(Owner.Limit < money)) throw new Exception("TrustLimit");
            if (Balance - money >= 0)
            {
                Balance -= money;
                return true;
            }
            if (!(Balance - money - commision > limit)) return false;
            Balance = Balance - money - commision;
            return true;
        }

        public override void CountBonus()
        {
        }

        public override void AddBonus()
        {
        }
    }
} 