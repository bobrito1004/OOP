namespace lab2
{
    public class Item
    {
        private static int _idCounter = 1;
        private int _id;
        private string _name;

        protected Item()
        {
            _id = 0;
            _name = "";
        }

        public Item(string name)
        {
            _id = _idCounter;
            _idCounter++;
            _name = name;
        }

        public int get_id()
        {
            return _id;
        }

        public string get_name()
        {
            return _name;
        }

        public class ItemForSale : Item
        {
            private int _amount;
            private int _price;

            public ItemForSale(Item parent, int amount, int price)
            {
                _id = parent._id;
                _name = parent._name;
                _amount = amount;
                _price = price;
            }

            public int get_price()
            {
                return _price;
            }

            public int get_amount()
            {
                return _amount;
            }
        }
    }
}