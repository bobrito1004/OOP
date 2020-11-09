using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    public class Shop
    {
        private static int _idCounter = 1;
        private int _id;
        private string _name;
        private string _address;
        private List<Item.ItemForSale> item_list = new List<Item.ItemForSale>();


        public Shop(string name, string address)
        {
            _id = _idCounter;
            _idCounter++;
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public void add_product(Item it, int amout, int price)
        {
            var newIt = new Item.ItemForSale(it, amout, price);
            item_list.Add(newIt);
        }

        public bool Contains(Item it)
        {
            return item_list.Any(pr => pr.get_id() == it.get_id());
        }

        public int GetItemPrice(Item it)
        {
            try
            {
                foreach (var pr in item_list.Where(pr => pr.get_id() == it.get_id()))
                {
                    return pr.get_price();
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private int GetItemAmount(Item it)
        {
            try
            {
                if (Contains(it))
                {
                    foreach (var pr in item_list.Where(pr => pr.get_id() == it.get_id()))
                    {
                        return pr.get_amount();
                    }

                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 0;
        }

        public void YouCanBuy(int n)
        {
            if (n < 1)
            {
                Console.WriteLine("You can`t buy anything");
            }
            else
            {
                try
                {
                    foreach (var pr in item_list)
                    {
                        var amount = n / pr.get_price();
                        if (amount != 0)
                        {
                            Console.WriteLine(amount > pr.get_amount()
                                ? $"In {_name} you can buy {pr.get_amount()} {pr.get_name()}"
                                : $"In {_name} you can buy {amount} {pr.get_name()}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public int Buy(Item it, int amount)
        {
            foreach (var pr in item_list.Where(pr => pr.get_id() == it.get_id()))
            {
                if (amount > pr.get_amount())
                {
                    throw new Exception("Not enough products");
                }
                return amount * pr.get_price();
            }
            return 0;
        }

        public int GetDeal(Dictionary<Item, int> d)
        {
            var availableItems = 0;
            var total = -1;
            foreach (var item in d)
            {
                if (!Contains(item.Key)) throw new Exception($"Shop doesnt have {item.Key}");
                if (GetItemAmount(item.Key) == 0 || GetItemAmount(item.Key) < item.Value)
                    throw new Exception($"Not enough of {item.Key}");
                availableItems++;
                total += GetItemPrice(item.Key) * item.Value;
            }

            if (availableItems == d.Count)
            {
                return total;
            }

            throw new Exception();
        }
    }
}