using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public class DepositAccount : Account
    {
        private DateTime stamp;
        private double Percent;
        private double bonus;
        public DepositAccount(Client c, double money, int years, Dictionary<double, double> perc) : base(c)
        {
            if (perc.Last().Key <= money)
            {
                Percent = perc.Last().Value;
            }
            else
            {
                foreach (var item in perc)
                {
                    if (money > item.Key)
                    {
                        continue;
                    }
                    Percent = item.Value;
                    break;
                }
                
            }
            Percent = money * Percent;
            stamp = DateTime.Now.AddYears(years);
        }
        public override bool Withdraw(double money)
        {
            if (DateTime.Now < stamp) throw new Exception("Cant withdraw yet");
            if (!(Balance - money >= 0)) return false;
            Balance -= money;
            return true;
        }

        public override void CountBonus()
        {
            bonus += Balance * (Percent / 100);
        }

        public override void AddBonus()
        {
            Balance += Percent;
        }
    }
}