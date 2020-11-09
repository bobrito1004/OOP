﻿using System;
using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
             var a = new Item("apple");
             var b = new Item("banana");
             var c = new Item("coco");
             var sh1 = new Shop("Пятёрочка", "adr");
             var sh2 = new Shop("Шестёрочка", "adr");
             var sh3 = new Shop("Семёрочка", "adr");
             sh1.add_product(a, 20, 13);
             sh1.add_product(b, 100, 2);
             sh2.add_product(a, 100, 2);
             sh2.add_product(b, 100, 1);
             sh3.add_product(a, 20, 1);
             sh3.add_product(b, 10, 3);
             sh3.add_product(c, 5, 100);
             var sl = new ShopList();
             sl.Add(sh1);
             sl.Add(sh2);
             sl.Add(sh3);
             Console.WriteLine(sl.FindCheapest(a));
             sh1.YouCanBuy(100);
             Console.WriteLine(sh1.Buy(a, 3));
             var d = new Dictionary<Item, int> {{a, 1}, {b, 2}};
             Console.WriteLine(sl.FindCheapestDeal(d).GetName());
        }
    }
}