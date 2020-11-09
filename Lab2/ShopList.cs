using System;
using System.Collections.Generic;
using System.Linq;


namespace lab2
{
    public class ShopList
    {
        List<Shop> lst = new List<Shop>();

        public void Add(Shop sh)
        {
            lst.Add(sh);
        }

        public Shop FindCheapest(Item it)
        {
            var least = -1;
            Shop ret = null;

            foreach (var shop in lst.Where(shop => shop.Contains(it)))
            {
                if (least == -1)
                {
                    least = shop.GetItemPrice(it);
                    ret = shop;
                    continue;
                }

                if (least <= shop.GetItemPrice(it)) continue;
                least = shop.GetItemPrice(it);
                ret = shop;
            }

            if (ret == null) throw new Exception($"None of shops has {it.get_name()}");
            return ret;
        }

        public Shop FindCheapestDeal(Dictionary<Item, int> d)
        {
            if (lst.Count == 0)
            {
                throw new Exception("No shops found");
            }
            
            var priceList = new Dictionary<Shop, int>();
            foreach (var shop in lst)
            {
                try
                {
                    priceList.Add(shop, shop.GetDeal(d));
                }
                catch (Exception) {}
            }

            if (priceList.Count == 0)
            {
                throw new Exception("None of the shops has items you need");
            }
            var bestDeal = priceList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).First().Key;
            return bestDeal;
        }
    }
}