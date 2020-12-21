namespace Lab5
{
    public class CreateClient
    {
        private Client _client;

        public CreateClient(Client c)
        {
            _client = c;
        }

        public CreateClient()
        {
            _client = new Client();
        }

        public CreateClient SetName(string first, string second)
        {
            _client.FirstName = first;
            _client.SecondName = second;
            return this;
        }

        public CreateClient SetAddress(string addr)
        {
            _client.Address = addr;
            if (_client.Passport != null)
            {
                _client.IsTrusted = true;
            }
            return this;
        }

        public CreateClient SetId(string p)
        {
            _client.Passport = p;
            if (_client.Address != null)
            {
                _client.IsTrusted = true;
            }
            return this;
        }

        public Client Build()
        {
            _client.Trusted();
            return _client;
        }
    }
}