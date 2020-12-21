namespace Lab5
{
    public abstract class Account
    {
        public double Balance;
        public int Id;
        public Client Owner;
        public double initialPerc;
        public Account(Client client)
        {
            initialPerc = 0;
            Id = 0;
            Owner = client;
            Balance = 0;
            client.Accounts.Add(this);
        }

        public double GetBalance()
        {
            return Balance;
        }

        public abstract bool Withdraw(double money);
        public abstract void CountBonus();
        public abstract void AddBonus();

        public void AddMoney(double money)
        {
            Balance += money;
        }
    }
}